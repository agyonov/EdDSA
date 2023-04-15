﻿namespace CryptoEx.JWK;

/// <summary>
/// Various constants used in JWK.
/// </summary>
public static partial class JwkConstants
{
    #region JWK Key Types

    /// <summary>
    /// Simetric
    /// </summary>
    public const string OCT = "oct";
    /// <summary>
    /// Eliptic Curve
    /// </summary>
    public const string EC = "EC";
    /// <summary>
    /// RSA
    /// </summary>
    public const string RSA = "RSA";

    #endregion

    #region EC Curves

    /// <summary>
    /// P-256 NISP
    /// </summary>
    public const string CurveP256 = "P-256";
    /// <summary>
    /// P-384 NISP
    /// </summary>
    public const string CurveP384 = "P-384";
    /// <summary>
    /// P-521 NISP
    /// </summary>
    public const string CurveP521 = "P-521";

    #endregion EC Curves
}
