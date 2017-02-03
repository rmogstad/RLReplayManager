using RocketLeagueReplayParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLReplayManager
{
    class ReplayHeader
    {

        public string ReplayFile;
        public string ReplayName { get; set; } //'ReplayName'
        public string Mode { get; set; }
        public int TeamSize; //'TeamSize'
        public int BlueTeamScore { get; set; } //'Team0Score'
        public int OrangeTeamScore { get; set; } //'Team1Score'
        public string PlayerName { get; set; } //'PlayerName'
        public int PlayerTeam; //'PrimaryPlayerTeam'
        public string MatchType { get; set; } //'MatchType'
        public string MapName { get; set; } //'MapName'
        public string Date { get; set; } //'Date'
        public List<Player> BlueTeamPlayers; //From 'PlayerStats'
        public List<Player> OrangeTeamPlayers; //From 'PlayerStats'


        //private RocketLeagueReplayParser.Replay parsedHeader;
        public static ReplayHeader DeserializeHeader(string filePath)
        {
            var parsedHeader = RocketLeagueReplayParser.Replay.DeserializeHeader(filePath);

            var stats = (List<PropertyDictionary>)parsedHeader.Properties["PlayerStats"].Value;
            List<Player> BluePlayers = null;
            List<Player> OrangePlayers = null;
            foreach (PropertyDictionary SinglePlayer in stats)
            {
                Player player = new Player();
                foreach (KeyValuePair<string, Property> stat in SinglePlayer)
                {
                    switch (stat.Key)
                    {
                        case "Name":
                            player.Name = (string)stat.Value.Value;
                            break;
                        case "Platform":
                            var platform = (string)((EnumPropertyValue)stat.Value.Value).Value;
                            switch (platform)
                            {
                                case "OnlinePlatform_Steam":
                                    player.Platform = "Steam";
                                    break;
                                case "OnlinePlatform_PS4":
                                    player.Platform = "PS4";
                                    break;
                                case "OnlinePlatform_Dingo":
                                    player.Platform = "Xbox";
                                    break;
                            }

                            break;
                        case "Team":
                            player.Team = (int)stat.Value.Value;
                            break;
                        case "Goals":
                            player.Goals = (int)stat.Value.Value;
                            break;
                        case "Assists":
                            player.Assists = (int)stat.Value.Value;
                            break;
                        case "Saves":
                            player.Saves = (int)stat.Value.Value;
                            break;
                        case "Shots":
                            player.Shots = (int)stat.Value.Value;
                            break;
                        default:
                            break;
                    }
                }

                if (player.Team == 0)
                {
                    if (BluePlayers == null)
                    {
                        BluePlayers = new List<Player>();
                    }
                    BluePlayers.Add(player);
                }
                else
                {
                    if (OrangePlayers == null)
                    {
                        OrangePlayers = new List<Player>();
                    }
                    OrangePlayers.Add(player);
                }
            }
            Debug.WriteLine(GetStringOrEmpty(parsedHeader, "ReplayName"));
            return new ReplayHeader {
                ReplayFile = filePath,
                ReplayName = GetStringOrEmpty(parsedHeader, "ReplayName"),
                Mode = string.Format("{0}v{0}", GetIntOrZero(parsedHeader, "TeamSize")),
                TeamSize = GetIntOrZero(parsedHeader, "TeamSize"),
                BlueTeamScore = GetIntOrZero(parsedHeader, "Team0Score"),
                OrangeTeamScore = GetIntOrZero(parsedHeader, "Team1Score"),
                PlayerName = GetStringOrEmpty(parsedHeader, "PlayerName"),
                PlayerTeam = GetIntOrZero(parsedHeader, "PrimaryPlayerTeam"),
                MatchType = GetStringOrEmpty(parsedHeader, "MatchType"),
                MapName = GetStringOrEmpty(parsedHeader, "MapName"),
                Date = new FileInfo(filePath).CreationTime.ToString(),
                BlueTeamPlayers = BluePlayers,
                OrangeTeamPlayers = OrangePlayers
            };
        }


        private static int GetIntOrZero(Replay header, string propertyName)
        {
            Property val;
            return (int)(header.Properties.TryGetValue(propertyName, out val) ? val.Value : 0);
        }

        private static string GetStringOrEmpty(Replay header, string propertyName)
        {
            Property val;
            return (string)(header.Properties.TryGetValue(propertyName, out val) ? val.Value : "");
        }




        public struct Player
        {
            public string Name { get; set; }
            public int Goals { get; set; }
            public int Assists { get; set; }
            public int Saves { get; set; }
            public int Shots { get; set; }
            public int Team;
            public string Platform { get; set; }
        }     

    }
}
