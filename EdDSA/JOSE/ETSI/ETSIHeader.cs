﻿using System.Text.Json.Serialization;

namespace EdDSA.JOSE.ETSI;


public record class ETSIHeader : JWSHeader
{
    [JsonPropertyName("typ")]
    public override string? Typ
    {
        get {
            return "jose+json";
        }
        set {
            // No wai
        }
    }
    [JsonPropertyName("sigT")]
    public string SigT { get; set; } = string.Empty;
    [JsonPropertyName("adoTst")]
    public ETSITimestampContainer? AdoTst { get; set; } = null;
    [JsonPropertyName("sigD")]
    public ETSIDetachedParts? SigD { get; set; } = null;
    [JsonPropertyName("crit")]
    public string[] Crit
    {
        get {
            List<string> build = new List<string>
            {
                "sigT"
            };
            if (SigD != null) {
                build.Add("sigD");
            }
            if (AdoTst != null) {
                build.Add("adoTst");
            }
            return build.ToArray();
        }
    }
}
