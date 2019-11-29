﻿using System;

namespace PhilipDaubmeier.GraphIoT.Digitalstrom.Config
{
    public class DigitalstromConfig
    {
        public string TokenAppId { get; set; } = null!;
        public string DssUsername { get; set; } = null!;
        public string DssPassword { get; set; } = null!;

        public string DssCertificate { get; set; } = null!;

        public string DssUriLocal { get; set; } = null!;
        public string DssUriDsNet { get; set; } = null!;
        public string DssUriCloudredir { get; set; } = null!;

        public string CloudDssId { get; set; } = null!;
        public string CloudredirToken { get; set; } = null!;

        public bool UseCloudredir { get; set; }

        public string Proxy { get; set; } = null!;
        public string ProxyPort { get; set; } = null!;

        public Uri? UriLocal => string.IsNullOrWhiteSpace(DssUriLocal) ? null : new Uri(DssUriLocal);
        public Uri UriDsNet => new Uri(DssUriDsNet.Replace("{CloudDssId}", CloudDssId));
        public Uri UriCloudredir => new Uri(DssUriCloudredir.Replace("{CloudDssId}", CloudDssId).Replace("{CloudredirToken}", CloudredirToken));
    }
}