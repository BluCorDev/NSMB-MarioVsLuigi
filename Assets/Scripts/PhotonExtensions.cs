using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using Photon.Pun;
using Photon.Realtime;

public static class PhotonExtensions {

    private static readonly Dictionary<string, string> SPECIAL_PLAYERS = new() {
        ["00444ae89a3a1b331d44b7917207a27d7342451fa29e33d7f8c996a608e1aa06"] = "BluCor",
        ["2a8417e483aa195f7f00ebe10b84262a4b8b0d85a0930d87c4aa52817bb28a67"] = "SLGJaron",
        ["2a8417e483aa195f7f00ebe10b84262a4b8b0d85a0930d87c4aa52817bb28a67"] = "funnytophatman",
        ["933d958d6d0395425828a75a7ad07c4c7503d500f8d29939cdba6990f12ba50a"] = "among",
        ["933d958d6d0395425828a75a7ad07c4c7503d500f8d29939cdba6990f12ba50a"] = "cocainesunk",
        ["a9ee0e472c4c5b7a78a16547731fdced2dcc0062556d9f140dfc1c71414ccb17"] = "Foxyyy",
        ["74478e52b28f3de827755481a2175e68fbfcc671c4bfe702ccd4ac2c7d53a58e"] = "FrostyCake",
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