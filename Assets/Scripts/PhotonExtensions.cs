using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using Photon.Pun;
using Photon.Realtime;

public static class PhotonExtensions {

    private static readonly Dictionary<string, string> SPECIAL_PLAYERS = new() {
        ["cf03abdb5d2ef1b6f0d30ae40303936f9ab22f387f8a1072e2849c8292470af1"] = "ipodtouch0218",
        ["d5ba21667a5da00967cc5ebd64c0d648e554fb671637adb3d22a688157d39bf6"] = "mindnomad",
        ["95962949aacdbb42a6123732dabe9c7200ded59d7eeb39c889067bafeebecc72"] = "MPS64",
        ["7e9c6f2eaf0ce11098c8a90fcd9d48b13017667e33d09d0cc5dfe924f3ead6c1"] = "Fawndue",
        ["00444ae89a3a1b331d44b7917207a27d7342451fa29e33d7f8c996a608e1aa06"] = "BluCor",
        ["2a8417e483aa195f7f00ebe10b84262a4b8b0d85a0930d87c4aa52817bb28a67"] = "SLGJaron",
        ["2a8417e483aa195f7f00ebe10b84262a4b8b0d85a0930d87c4aa52817bb28a67"] = "funnytophatman",
        ["933d958d6d0395425828a75a7ad07c4c7503d500f8d29939cdba6990f12ba50a"] = "among",
        ["933d958d6d0395425828a75a7ad07c4c7503d500f8d29939cdba6990f12ba50a"] = "cocainesunk",
        ["c759b98244d2e44c37d27d1202cac3375eb01b1d13156ba8f8dc49b50500468a"] = "EmptySouls",
        ["a9ee0e472c4c5b7a78a16547731fdced2dcc0062556d9f140dfc1c71414ccb17"] = "Foxyyy",
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