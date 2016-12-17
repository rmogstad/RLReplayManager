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

        public struct Property
        {
            public string Name;
            public string Type;
            public Int32 DataLength;
            public Int32 Unknown2;
            public Int64? IntValue;
            public string StringValue;
            public string StringValue2;
            public float FloatValue;
            public List<List<Property>> ArrayValue;
        }

     

        public static ReplayHeader DeserializeHeader(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var br = new BinaryReader(fs))
            {
                var header = DeserializeHeader(br);
                header.ReplayFile = filePath;
                header.Date = new FileInfo(filePath).CreationTime.ToString();
                return header;
            }
        }

        private static ReplayHeader DeserializeHeader(BinaryReader br)
        {

            br.ReadInt32(); //Part1 length
            br.ReadUInt32(); //Part1 CRC
            br.ReadUInt32(); //Major Version
            br.ReadUInt32(); //Minor Version
            br.ReadString2(); //Unknown

            ReplayHeader header = new ReplayHeader();

            Property prop;
            do
            {
                prop = DeserializeProperty(br);
                switch (prop.Name)
                {
                    case "ReplayName":
                        header.ReplayName = prop.StringValue;
                        break;
                    case "TeamSize":
                        header.TeamSize = (int)prop.IntValue;
                        header.Mode = string.Format("{0}v{0}", header.TeamSize);
                        break;
                    case "Team0Score":
                        header.BlueTeamScore = (int)prop.IntValue;
                        break;
                    case "Team1Score":
                        header.OrangeTeamScore = (int)prop.IntValue;
                        break;
                    case "PlayerName":
                        header.PlayerName = prop.StringValue;
                        break;
                    case "PrimaryPlayerTeam":
                        header.PlayerTeam = (int)prop.IntValue;
                        break;
                    case "MatchType":
                        header.MatchType = prop.StringValue;
                        break;
                    case "MapName":
                        header.MapName = prop.StringValue;
                        break;
                    //case "Date":
                        
                    //    break;
                    case "PlayerStats":
                        var stats = prop.ArrayValue;
                        foreach (List<Property> SinglePlayer in stats)
                        {
                            Player player = new Player();
                            foreach (Property stat in SinglePlayer)
                            {
                                switch (stat.Name)
                                {
                                    case "Name":
                                        player.Name = stat.StringValue;
                                        break;
                                    case "Platform":
                                        var platform = stat.StringValue2;
                                        switch(platform)
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
                                        player.Team = (int)stat.IntValue;
                                        break;
                                    case "Goals":
                                        player.Goals = (int)stat.IntValue;
                                        break;
                                    case "Assists":
                                        player.Assists = (int)stat.IntValue;
                                        break;
                                    case "Saves":
                                        player.Saves = (int)stat.IntValue;
                                        break;
                                    case "Shots":
                                        player.Shots = (int)stat.IntValue;
                                        break;
                                    default:
                                        break;
                                }
                            }

                            if (player.Team == 0)
                            {
                                if (header.BlueTeamPlayers == null)
                                {
                                    header.BlueTeamPlayers = new List<Player>();
                                }
                                header.BlueTeamPlayers.Add(player);
                            }
                            else
                            {
                                if (header.OrangeTeamPlayers == null)
                                {
                                    header.OrangeTeamPlayers = new List<Player>();
                                }
                                header.OrangeTeamPlayers.Add(player);
                            }
                        }

                        break;
                    default:
                        Debug.WriteLine("Found " + prop.Name + " but we aren't looking at it...");
                        break;
                }
            }
            while (prop.Name != "None");

            return header;
        }

        public static Property DeserializeProperty(BinaryReader bs)
        {
            var p = new Property();
            p.Name = bs.ReadString2();
            if (p.Name != "None")
            {
                p.Type = bs.ReadString2();

                p.DataLength = bs.ReadInt32();
                p.Unknown2 = bs.ReadInt32();

                if (p.Type == "IntProperty")
                {
                    p.IntValue = bs.ReadInt32();
                }
                else if (p.Type == "StrProperty" || p.Type == "NameProperty")
                {
                    p.StringValue = bs.ReadString2();
                }
                else if (p.Type == "FloatProperty")
                {
                    p.FloatValue = bs.ReadSingle();
                }
                else if (p.Type == "ByteProperty")
                {
                    // how is this a byte property?
                    p.StringValue = bs.ReadString2();
                    p.StringValue2 = bs.ReadString2();
                }
                else if (p.Type == "BoolProperty")
                {
                    p.IntValue = bs.ReadByte();
                }
                else if (p.Type == "QWordProperty")
                {
                    p.IntValue = bs.ReadInt64();
                }
                else if (p.Type == "ArrayProperty")
                {
                    p.ArrayValue = new List<List<Property>>();
                    var len = bs.ReadInt32();
                    for (int i = 0; i < len; ++i)
                    {
                        var properties = new List<Property>();
                        Property prop;
                        do
                        {
                            prop = DeserializeProperty(bs);
                            properties.Add(prop);
                        }
                        while (prop.Name != "None");
                        p.ArrayValue.Add(properties);

                    }
                }
                else
                {
                    throw new InvalidDataException("Unknown property: " + p.Type);
                }

            }

            return p;
        }

    }
}
