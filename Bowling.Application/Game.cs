﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Model;
using Bowling.Spec;

namespace Bowling.Application
{
    public class Game
    {
        private Frames _frames = new Frames(FrameCountRule.GetCount());
        private IFileSystem _fileSystem;

        /// <summary>
        /// For test only
        /// </summary>
        public Game()
        {
        }

        public Game(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Roll(int p)
        {
            _frames = RollService.Roll(_frames, p);
        }

        public Score CalcScore()
        {
            return ScoreService.Calc(_frames);
        }

        public void Save(string path)
        {
            SaveService.Save(_frames, path, _fileSystem);
        }

        public bool IsEnd()
        {
            return RollService.IsEnd(_frames);
        }

        public IEnumerable<Frame> GetFrames()
        {
            foreach (Frame f in _frames)
            {
                yield return f;
            }
        }

        public Score CalcScoreAt(int index)
        {
            return ScoreService.CalcAt(_frames, index);
        }

        public bool IsFullAt(int i)
        {
            return FullFrameRule.IsFull(_frames[i]);
        }

        public void Load(string path)
        {
            LoadService.Load(_frames, path);
        }
    }
}
