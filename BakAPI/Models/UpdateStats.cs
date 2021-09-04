using BakAPI.Controllers;
using BakAPI.Data;
using BakAPI.IRepository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakAPI.Models
{
    public static class UpdateStats
    {
        //public Game _currentGame;
        //private readonly IUnitOfWork _unitOfWork;
        //public EloSystem(Game currentGame, IUnitOfWork unitOfWork)
        //{
        //    _currentGame = currentGame;
        //    _unitOfWork = unitOfWork;
        //}
        public static async Task<double[]> Update_Elo_PlayerStats(Game game, IUnitOfWork unitOfWork, ILogger<GameController> _logger)
        {
            Game _game = game;
            IUnitOfWork _unitOfWork = unitOfWork;

            // Elo per duo
            Duo DuoRed = await _unitOfWork.Duos.Get(d => d.Id == game.DuoRedId);
            Duo DuoGre = await _unitOfWork.Duos.Get(d => d.Id == game.DuoGreId);
            Player RedDefPlayer = await _unitOfWork.Players.Get(p => p.Id == _game.RedDefId);
            Player RedOffPlayer = await _unitOfWork.Players.Get(p => p.Id == _game.RedOffId);
            Player GreDefPlayer = await _unitOfWork.Players.Get(p => p.Id == _game.GreDefId);
            Player GreOffPlayer = await _unitOfWork.Players.Get(p => p.Id == _game.GreOffId);

            double correctedWinRateRed = CorrectWinRate(DuoRed.WinRate, DuoRed.NumberOfGames);
            double correctedWinRateGre = CorrectWinRate(DuoGre.WinRate, DuoGre.NumberOfGames);

            double winChanceRed = 1 / (1 + Math.Pow(10,100*(correctedWinRateGre - correctedWinRateRed)));
            double winChanceGre = 1 / (1 + Math.Pow(10,100*(correctedWinRateRed - correctedWinRateGre)));

            double deltaEloRed;
            double deltaEloGre;
            bool redWins = _game.RedScore > _game.GreScore;
            if (redWins)
            {
                deltaEloRed = 65 * (1 - winChanceRed);
                deltaEloGre = 55 * (-winChanceGre) + 10;

            }
            else
            {
                deltaEloRed = 55 * (-winChanceRed) + 10;
                deltaEloGre = 65 * (1 - winChanceRed);
            }

            // Elo per player
            double correctedWinRateRedDef = CorrectWinRate(RedDefPlayer.WinRate, RedDefPlayer.GameAmount);
            double correctedWinRateRedOff = CorrectWinRate(RedOffPlayer.WinRate, RedOffPlayer.GameAmount);
            double correctedWinRateGreDef = CorrectWinRate(GreDefPlayer.WinRate, GreDefPlayer.GameAmount);
            double correctedWinRateGreOff = CorrectWinRate(GreOffPlayer.WinRate, GreOffPlayer.GameAmount);

            double WinChanceRedDef = 1 / (1 + Math.Pow(10, (correctedWinRateGreOff - correctedWinRateRedDef) * 1.5));
            double WinChanceGreDef = 1 / (1 + Math.Pow(10, (correctedWinRateRedOff - correctedWinRateGreDef) * 1.5));
            double WinChanceRedOff = 1 / (1 + Math.Pow(10, (correctedWinRateGreDef + correctedWinRateGreOff) / (2 - correctedWinRateRedOff) * 2.5));
            double WinChanceGreOff = 1 / (1 + Math.Pow(10, (correctedWinRateRedDef + correctedWinRateRedOff) / (2 - correctedWinRateGreOff) * 2.5));

            double deltaEloRedDef = deltaEloRed * (1 + 0.5 - WinChanceRedDef);
            double deltaEloRedOff = deltaEloRed * (1 + 0.5 - WinChanceRedOff);
            double deltaEloGreDef = deltaEloGre * (1 + 0.5 - WinChanceGreDef);
            double deltaEloGreOff = deltaEloGre * (1 + 0.5 - WinChanceGreOff);

            // Individual Bonus
            int[] scores = { _game.RedScore, _game.GreScore };
            double normalizedGoalsRedDef = _game.RedDefScore * 11 / scores.Max();
            double normalizedGoalsRedOff = _game.RedOffScore * 11 / scores.Max();
            double normalizedGoalsGreDef = _game.GreDefScore * 11 / scores.Max();
            double normalizedGoalsGreOff = _game.GreOffScore * 11 / scores.Max();
            //Todo: averageGoals based on previous data
            double averageGoalsDef = 3;
            double averageGoalsOff = 7;

            double diffRedDef = normalizedGoalsRedDef - averageGoalsDef;
            double diffRedOff = normalizedGoalsRedOff - averageGoalsOff;
            double diffGreDef = normalizedGoalsGreDef - averageGoalsDef;
            double diffGreOff = normalizedGoalsGreOff - averageGoalsOff;

            // RedOff
            if (diffRedOff > 0) deltaEloRedOff += diffRedOff * 3 - diffGreDef * 4 - diffGreOff * 2;
            else deltaEloRedOff += diffRedOff * 3 - diffGreDef * 4 - diffGreOff * 2;

            // GreOff
            if (diffGreOff > 0) deltaEloGreOff += diffGreOff * 3 - diffRedDef * 4 - diffRedOff * 2;
            else deltaEloGreOff += diffGreOff * 3 - diffRedDef * 4 - diffRedOff * 2;

            // RedDef
            if (diffRedDef > 0)
            {
                deltaEloRedDef += diffRedDef * 5;
            }
            if (diffGreOff < 0)
            {
                deltaEloRedDef -= diffGreOff * 5;
            }
            if (diffRedOff > 0)
            {
                deltaEloRedDef += diffRedOff * 2;
            }
            // GreDef
            if (diffGreDef > 0)
            {
                deltaEloGreDef += diffGreDef * 5;
            }
            if (diffRedOff < 0)
            {
                deltaEloGreDef -= diffRedOff * 5;
            }
            if (diffGreOff > 0)
            {
                deltaEloGreDef += diffGreOff * 2;
            }

            // TeamBonus
            double redBonus = 0;
            if (!redWins)
            {
                if (_game.RedScore > 8) redBonus += 5;
                else if (_game.RedScore < 3.5) redBonus -= 5;
            }
            else if (_game.GreScore == 0) redBonus += 50;
            else if (_game.GreScore < 3.5) redBonus += 5;

            double greBonus = 0;
            if (redWins)
            {
                if (_game.GreScore > 8) greBonus += 5;
                else if (_game.GreScore < 3.5) greBonus -= 5;
            }
            else if (_game.RedScore == 0) greBonus += 50;
            else if (_game.RedScore < 3.5) greBonus += 5;

            deltaEloRedDef += redBonus;
            deltaEloRedOff += redBonus;
            deltaEloGreDef += greBonus;
            deltaEloRedOff += greBonus;

            RedDefPlayer.Elo += deltaEloRedDef;
            RedOffPlayer.Elo += deltaEloRedOff;
            GreDefPlayer.Elo += deltaEloGreDef;
            GreOffPlayer.Elo += deltaEloGreOff;
        
            RedDefPlayer = await Initialize_PlayerStats(RedDefPlayer,_unitOfWork);
            RedOffPlayer = await Initialize_PlayerStats(RedOffPlayer,_unitOfWork);
            GreDefPlayer = await Initialize_PlayerStats(GreDefPlayer,_unitOfWork);
            GreOffPlayer = await Initialize_PlayerStats(GreOffPlayer,_unitOfWork);

            DuoRed = await Initialize_DuoStats(DuoRed,_unitOfWork);
            DuoGre = await Initialize_DuoStats(DuoGre,_unitOfWork);

            _unitOfWork.Players.Update(RedDefPlayer);
            await _unitOfWork.Save();

            _unitOfWork.Players.Update(RedOffPlayer);
            await _unitOfWork.Save();

            _unitOfWork.Players.Update(GreDefPlayer);
            await _unitOfWork.Save();

            _unitOfWork.Players.Update(GreOffPlayer);
            await _unitOfWork.Save();

            _logger.LogInformation("Updating first duo");
            _unitOfWork.Duos.Update(DuoRed);
            _logger.LogInformation("Saving first duo");

            await _unitOfWork.Save();
            _logger.LogInformation("Updating second duo");

            _unitOfWork.Duos.Update(DuoGre);
            _logger.LogInformation("Saving second duo");

            game.RedDefDeltaElo = deltaEloRedDef;
            game.RedOffDeltaElo = deltaEloRedOff;
            game.GreOffDeltaElo = deltaEloGreOff;
            game.GreDefDeltaElo = deltaEloGreDef;

            _unitOfWork.Games.Update(game);

            await _unitOfWork.Save();
            return new double[4] { deltaEloRedDef, deltaEloRedOff, deltaEloGreDef, deltaEloGreOff };


        }

        private static double CorrectWinRate(double WinRate, int numberOfGames)
        {
            double correctedWinRate;
            if ((WinRate == 0 && numberOfGames <= 3)|| (WinRate == 1 && numberOfGames <= 3))
            {
                correctedWinRate = 0.5;
            }
            else if (WinRate < 0.35 && numberOfGames > 3)
            {
                correctedWinRate = 0.35;
            }
            else if ( WinRate > 0.65 && numberOfGames > 3)
            {
                correctedWinRate = 0.65;
            }
            else
            {
                correctedWinRate = WinRate;
            }
            return correctedWinRate;
        }

        private static async void Update_PlayerStats_FromGame(Game _currentGame, IUnitOfWork _unitOfWork)
        {
            var redDefPlayer = await _unitOfWork.Players.Get(p => p.Id == _currentGame.RedDefId);
            var redOffPlayer = await _unitOfWork.Players.Get(p => p.Id == _currentGame.RedDefId);
            var greDefPlayer = await _unitOfWork.Players.Get(p => p.Id == _currentGame.RedDefId);
            var greOffPlayer = await _unitOfWork.Players.Get(p => p.Id == _currentGame.RedDefId);

            bool redWins = _currentGame.RedScore > _currentGame.GreScore;
            int redWin;
            int greWin;
            if (redWins)
            {
                redWin = 1;
                greWin = 0;
            }
            else
            {
                redWin = 0;
                greWin = 1;
            }
            redDefPlayer.RedDefAmount += 1;
            redDefPlayer.GoalAmountDef += _currentGame.RedDefScore;
            redDefPlayer.WinDefAmount += redWin;

            redOffPlayer.RedOffAmount += 1;
            redOffPlayer.GoalAmountOff += _currentGame.RedOffScore;
            redOffPlayer.WinOffAmount += redWin;

            greDefPlayer.GreDefAmount += 1;
            greDefPlayer.GoalAmountDef += _currentGame.GreDefScore;
            greDefPlayer.WinDefAmount += greWin;

            greOffPlayer.GreOffAmount += 1;
            greOffPlayer.GoalAmountOff += _currentGame.GreOffScore;
            greOffPlayer.WinOffAmount += greWin;

            Add_Calculated_PlayerStats(redDefPlayer);
            Add_Calculated_PlayerStats(redOffPlayer);
            Add_Calculated_PlayerStats(greDefPlayer);
            Add_Calculated_PlayerStats(greOffPlayer);



        }
        private static async Task<Player> Initialize_PlayerStats(Player _player, IUnitOfWork _unitOfWork)
        {
            _player.GoalAmountOff = 0;
            _player.GoalAmountDef = 0;
            _player.RedDefAmount = 0;
            _player.RedOffAmount = 0;
            _player.GreOffAmount = 0;
            _player.GreDefAmount = 0;
            _player.WinDefAmount = 0;
            _player.WinOffAmount = 0;

            var GamesRedDef = await _unitOfWork.Games.GetAll(g => g.RedDefId == _player.Id);
            var GamesRedOff = await _unitOfWork.Games.GetAll(g => g.RedOffId == _player.Id);
            var GamesGreDef = await _unitOfWork.Games.GetAll(g => g.GreDefId == _player.Id);
            var GamesGreOff = await _unitOfWork.Games.GetAll(g => g.GreOffId == _player.Id);

            var rank = await _unitOfWork.Ranks.Get(q => q.LowerBound <= _player.Elo && q.UpperBound >= _player.Elo);
            _player.RankId = rank.Id;

            //var GamesRedDef = _unitOfWork.Games()
            if (GamesRedDef != null)
            {
                foreach (Game game in GamesRedDef)
                {
                    bool redWins = game.RedScore > game.GreScore;
                    if (redWins) _player.WinDefAmount += 1;
                    _player.RedDefAmount += 1;
                    _player.GoalAmountDef += game.RedDefScore;
                }
            }
            
            if (GamesRedOff != null)
            {
                foreach (Game game in GamesRedOff)
                {
                    bool redWins = game.RedScore > game.GreScore;
                    if (redWins) _player.WinOffAmount += 1;
                    _player.RedOffAmount += 1;
                    _player.GoalAmountOff += game.RedOffScore;
                }
            }
            if (GamesGreDef != null)
            {
                foreach (Game game in GamesGreDef)
                {
                    bool redWins = game.RedScore > game.GreScore;
                    if (!redWins) _player.WinDefAmount += 1;
                    _player.GreDefAmount += 1;
                    _player.GoalAmountDef += game.GreDefScore;
                }
            }
            if (GamesGreOff != null)
            {
                foreach (Game game in GamesGreOff)
                {
                    bool redWins = game.RedScore > game.GreScore;
                    if (!redWins) _player.WinOffAmount += 1;
                    _player.GreOffAmount += 1;
                    _player.GoalAmountOff += game.GreOffScore;
                }
            }
            
     
            _player = Add_Calculated_PlayerStats(_player);
            return _player;
            



        }
        private static Player Add_Calculated_PlayerStats(Player _player)
        {
            _player.DefAmount = _player.RedDefAmount + _player.GreDefAmount;
            _player.OffAmount = _player.RedOffAmount + _player.GreOffAmount;
            _player.GameAmount = _player.DefAmount + _player.OffAmount;
            _player.WinAmount = _player.WinDefAmount + _player.WinOffAmount;
            _player.LossAmount = _player.GameAmount - _player.WinAmount; 
            _player.GoalAmount = _player.GoalAmountDef + _player.GoalAmountOff;

            try
            {
                _player.DefWinRate = (double)_player.WinDefAmount / _player.DefAmount;
            }
            catch (Exception)
            {

                _player.DefWinRate = 0.0;
            }
            try
            {
                _player.OffWinRate = (double)_player.WinOffAmount / _player.OffAmount;
            }
            catch (Exception)
            {

                _player.OffWinRate = 0.0;
            }
            try
            {
                _player.WinRate = (double)_player.WinAmount / _player.GameAmount;
            }
            catch (Exception)
            {

                _player.WinRate = 0.0;
            }

            
            try
            {
                _player.GoalMatchRate = (double)_player.GoalAmount / _player.GameAmount;

            }
            catch (Exception)
            {

                _player.GoalMatchRate = 0.0;
            }
            try
            {
                _player.GoalMatchRateDef = (double)_player.GoalAmountDef / _player.DefAmount;
            }
            catch (Exception)
            {

                _player.GoalMatchRateDef = 0.0;
            }
            try
            {
                _player.GoalMatchRateOff = (double)_player.GoalAmountOff / _player.OffAmount;
            }
            catch (Exception)
            {

                _player.GoalMatchRateOff = 0.0;
            }
            try
            {
                _player.GoalRateDef = (double)_player.GoalAmountDef / _player.GoalAmount;
            }
            catch (Exception)
            {

                _player.GoalRateDef = 0.0;
            }
            try
            {
                _player.GoalRateOff = (double)_player.GoalAmountOff / _player.GoalAmount;
            }
            catch (Exception)
            {

                _player.GoalRateOff = 0.0;
            }

            return _player;
        }

        private static async Task<Duo> Initialize_DuoStats(Duo _duo, IUnitOfWork _unitOfWork)
        {
            _duo.NumberOfGames = 0;
            var Wins = 0;
            var GamesRed = await _unitOfWork.Games.GetAll(g => g.DuoRedId == _duo.Id);
            var GamesGre = await _unitOfWork.Games.GetAll(g => g.DuoGreId == _duo.Id);

            if (GamesRed != null)
            {
                foreach (Game game in GamesRed)
                {
                    _duo.NumberOfGames += 1;
                    if (game.Winner == "Red")
                    {
                        Wins += 1;
                    }
                }
            }    
            if (GamesGre != null)
            {
                foreach (Game game in GamesGre)
                {
                    _duo.NumberOfGames += 1;
                    if (game.Winner == "Green")
                    {
                        Wins += 1;
                    }
                }
                
            }
            try
            {
                _duo.WinRate = (double)Wins / (double)_duo.NumberOfGames;
            }
            catch (Exception)
            {

                _duo.WinRate = 0;
            }

            return _duo;
            
        }
    }

}

