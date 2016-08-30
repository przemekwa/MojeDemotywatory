﻿

using MojeDemotywatoryNETCoreApi.Models;

namespace MojeDemotywatoryNETCoreApi.Buldiers
{
    public abstract class Builder
    {
        public string ImgUrl { get; set; }

        public string Url { get; set; }

        public string Describe { get; set; }

        public abstract Demotivator Build();
    }
}