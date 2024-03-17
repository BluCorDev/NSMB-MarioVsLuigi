using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using Photon.Pun;
using Photon.Realtime;

public static class PhotonExtensions {

    private static readonly Dictionary<string, string> SPECIAL_PLAYERS = new() {
        ["96b3ff9946cdf2e6678279a2d523e75ddeb12034b976c59af67913ba20bb8c1f"] = "BluCor",
        ["3d45e2b8eb586e10d4f49e3964b99cb403fb7a4c4792c57b8a6b085bb203807a"] = "Foxyyy",
        ["ffd345731c31c49b66a2c6398d6489fd1f19fe717ef78e0174fc4cbe7d4828cf"] = "FrostyCake",
        ["316424c21a3513d5e6294e7854615f3d0c13b4aaf09b2a443d2cfe0d0046d006"] = "zomblebobble",
    };

    public static bool IsMineOrLocal(this PhotonView view) {
        return !view || view.IsMine;
    }

    public static bool HasRainbowName(this Player player) {
        if (player == null || player.UserId == null)
            return false;

        byte[] bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(player.UserId));
        StringBuilder sb = new();
        foreach (byte b in bytes)
            sb.Append(b.ToString("X2"));

        string hash = sb.ToString().ToLower();
        return SPECIAL_PLAYERS.ContainsKey(hash) && player.NickName == SPECIAL_PLAYERS[hash];
    }

    //public static void RPCFunc(this PhotonView view, Delegate action, RpcTarget target, params object[] parameters) {
    //    view.RPC(nameof(action), target, parameters);
    //}
}