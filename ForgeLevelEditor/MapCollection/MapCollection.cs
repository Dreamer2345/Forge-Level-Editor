using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

using ForgeLevelEditor.map;

namespace ForgeLevelEditor.mapCollection
{
    public class MapCollection
    {
        public string FilePath = "";
        public string FileName = "";

        private int viewWidth = 10;
        private int viewHeight = 10;
        private int drawOffsetX = 0;
        private int drawOffsetY = 0;

        public int DrawOffsetX { get => drawOffsetX; set { drawOffsetX = value;  UpdateViewParams(); } }
        public int DrawOffsetY { get => drawOffsetY; set { drawOffsetY = value; UpdateViewParams(); } }
        public int ViewWidth { get => viewWidth; set { viewWidth = value; UpdateViewParams(); } }
        public int ViewHeight { get => viewHeight; set { viewHeight = value; UpdateViewParams(); } }

        void UpdateViewParams()
        {
            foreach(Map map in openMaps)
            {
                map.DrawOffsetX = drawOffsetX;
                map.DrawOffsetY = drawOffsetY;
                map.ViewHeight = viewHeight;
                map.ViewWidth = viewWidth;
            }
        }

        private bool drawBackground = true;
        private bool drawSprites = true;
        private bool drawConnections = true;
        private bool drawPlayer = true;

        private List<Map> openMaps = new List<Map>();
        public Map CurrentMap = null;

        public void MoveCurrentMapUp() {

            int index = openMaps.IndexOf(CurrentMap);
            openMaps.Remove(CurrentMap);
            openMaps.Insert(index - 1, CurrentMap);

        }

        public void MoveCurrentMapDown() {

            int index = openMaps.IndexOf(CurrentMap);
            openMaps.Remove(CurrentMap);
            openMaps.Insert(index + 1, CurrentMap);

        }

        public int OpenCount
        {
            get
            {
                return openMaps.Count;
            }
        }

        public bool DrawBackground { get => drawBackground; set => drawBackground = value; }
        public bool DrawSprites { get => drawSprites; set => drawSprites = value; }
        public bool DrawConnections { get => drawConnections; set => drawConnections = value; }
        public bool DrawPlayer { get => drawPlayer; set => drawPlayer = value; }

        public void AddMap(Map map)
        {
            map.DrawOffsetX = drawOffsetX;
            map.DrawOffsetY = drawOffsetY;
            map.ViewHeight = viewHeight;
            map.ViewWidth = viewWidth;
            if (CurrentMap == null)
                CurrentMap = map;
            openMaps.Add(map);
        }

        public void AddMaps(IEnumerable<Map> maps)
        {
            foreach(Map map in maps)
                if(map != null)
                    this.AddMap(map);
        }


        public void RemoveMap(Map map)
        {
            openMaps.Remove(map);
            if (map == CurrentMap)
            {
                CurrentMap = null;
                if(openMaps.Count > 0)
                    CurrentMap = openMaps[0];
            }
        }

        public bool ChangeMap(Map map)
        {
            if(CurrentMap == null)
            {
                if (openMaps.Count > 0)
                {
                    CurrentMap = openMaps[0];
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if(CurrentMap != map)
            {
                CurrentMap = map;
                return true;
            }
            return false;
        }

        public void Draw(Graphics graphics)
        {
            if (this.CurrentMap == null)
                return;

            if (drawBackground)
                CurrentMap.DrawBackground(graphics);

            if (drawSprites)
                CurrentMap.DrawSprites(graphics);

            if (drawConnections)
                CurrentMap.DrawConnections(graphics);

            if (drawPlayer)
                CurrentMap.DrawPlayer(graphics);
        }

        private static readonly Regex mapLoadRegex = new Regex(@"const\suint8_t\s*\S+\[\s*\]\s*\=\s*\{.*?\}\;");
        private static readonly HashSet<char> mapLoadCharacters = new HashSet<char>() { ',', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        
        public static IEnumerable<Map> LoadMaps(string filePath)
        {
            var fileData = string.Join(" ", File.ReadLines(filePath));

            for (Match match = mapLoadRegex.Match(fileData);  match.Success; match = match.NextMatch())
            {
                string[] values = match.Value.Split('{', '}');
                if (values.Length == 3)
                {
                    string nameArea = values[0];
                    int nameEnd = nameArea.IndexOf('[');
                    int nameStart = nameArea.IndexOf("uint8_t") + 7;
                    string name = nameArea.Substring(nameStart, nameEnd - nameStart).Trim();
                        
                    string arrayData = string.Join("", values[1].Where(mapLoadCharacters.Contains));

                    string[] splitData = arrayData.Split(',');
                    byte[] bytes = new byte[splitData.Length];
                    for (int i = 0; i < splitData.Length; i++)
                    {
                        if (byte.TryParse(splitData[i], out bytes[i]))
                        {
                                
                        }
                    }

                    Map map = Map.ParseMapArray(bytes, name);

                    if (map != null)
                        yield return map;
                }
            }
        }

        public void SaveMaps()
        {
            try
            {
                var savePath = Path.Combine(FilePath, FileName);

                using (var writer = new StreamWriter(savePath))
                {
                    writer.WriteLine("#pragma once");
                    writer.WriteLine();
                    writer.WriteLine("#include <stdint.h>");
                    writer.WriteLine();

                    foreach (var map in this.openMaps)
                    {
                        map.WriteMap(writer);
                        writer.WriteLine();
                    }

                    writer.WriteLine("constexpr const uint8_t numberOfMaps = {0};", openMaps.Count);
                    writer.WriteLine();

                    writer.Write("constexpr const uint8_t* maps[numberOfMaps] = ");
                    writer.Write("{ ");
                    foreach (var map in this.openMaps)
                    {
                        writer.Write(map.Name);
                        writer.Write(',');
                    }
                    writer.WriteLine(" };");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public List<Map> GetMaps()
        {
            return openMaps;
        }


    }
}
