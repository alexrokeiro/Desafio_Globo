using System;

namespace Desafio.Domain.Models
{
    public class Gravacao
    {
        private Gravacao() { }

        public Guid Id { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }
        public string Title { get; private set; }
        public string Duration { get; private set; }
        public long ReconcileKey { get; private set; }

        public static Gravacao Criar(string startTime, string endTime, string title, string duration, long reconcileKey)
        {
            var model = new Gravacao();
            model.Id = Guid.NewGuid();
            model.StartTime = startTime;
            model.EndTime = endTime;
            model.Title = title;
            model.Duration = duration;
            model.ReconcileKey = reconcileKey;

            return model;
        }
    }
}
