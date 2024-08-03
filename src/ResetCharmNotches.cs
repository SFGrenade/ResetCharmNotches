using System.Reflection;
using Modding;

namespace ResetCharmNotches;

public class ResetCharmNotches : Mod
{
    internal static ResetCharmNotches Instance;

    public override string GetVersion()
    {
        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }

    public override void Initialize()
    {
        Log("Initializing");
        Instance = this;

        InitCallbacks();

        Log("Initialized");
    }

    private void InitCallbacks()
    {
        // Hooks
        ModHooks.AfterSavegameLoadHook += OnAfterSavegameLoadHook;
        ModHooks.GetPlayerIntHook += OnGetPlayerIntHook;
    }

    private void OnAfterSavegameLoadHook(SaveGameData data)
    {
        var pd = PlayerData.instance;

        if (pd.gotCharm_1)
            pd.charmCost_1 = 1;
        if (pd.gotCharm_2)
            pd.charmCost_2 = 1;
        if (pd.gotCharm_3)
            pd.charmCost_3 = 1;
        if (pd.gotCharm_4)
            pd.charmCost_4 = 2;
        if (pd.gotCharm_5)
            pd.charmCost_5 = 2;
        if (pd.gotCharm_6)
            pd.charmCost_6 = 2;
        if (pd.gotCharm_7)
            pd.charmCost_7 = 3;
        if (pd.gotCharm_8)
            pd.charmCost_8 = 2;
        if (pd.gotCharm_9)
            pd.charmCost_9 = 3;
        if (pd.gotCharm_10)
            pd.charmCost_10 = 1;
        if (pd.gotCharm_11)
            pd.charmCost_11 = 3;
        if (pd.gotCharm_12)
            pd.charmCost_12 = 1;
        if (pd.gotCharm_13)
            pd.charmCost_13 = 3;
        if (pd.gotCharm_14)
            pd.charmCost_14 = 1;
        if (pd.gotCharm_15)
            pd.charmCost_15 = 2;
        if (pd.gotCharm_16)
            pd.charmCost_16 = 2;
        if (pd.gotCharm_17)
            pd.charmCost_17 = 1;
        if (pd.gotCharm_18)
            pd.charmCost_18 = 2;
        if (pd.gotCharm_19)
            pd.charmCost_19 = 3;
        if (pd.gotCharm_20)
            pd.charmCost_20 = 2;
        if (pd.gotCharm_21)
            pd.charmCost_21 = 4;
        if (pd.gotCharm_22)
            pd.charmCost_22 = 2;
        if (pd.gotCharm_23)
            pd.charmCost_23 = 2;
        if (pd.gotCharm_24)
            pd.charmCost_24 = 2;
        if (pd.gotCharm_25)
            pd.charmCost_25 = 3;
        if (pd.gotCharm_26)
            pd.charmCost_26 = 1;
        if (pd.gotCharm_27)
            pd.charmCost_27 = 4;
        if (pd.gotCharm_28)
            pd.charmCost_28 = 2;
        if (pd.gotCharm_29)
            pd.charmCost_29 = 4;
        if (pd.gotCharm_30)
            pd.charmCost_30 = 1;
        if (pd.gotCharm_31)
            pd.charmCost_31 = 2;
        if (pd.gotCharm_32)
            pd.charmCost_32 = 3;
        if (pd.gotCharm_33)
            pd.charmCost_33 = 2;
        if (pd.gotCharm_34)
            pd.charmCost_34 = 4;
        if (pd.gotCharm_35)
            pd.charmCost_35 = 3;
        if (pd.gotCharm_36) // Soul Fragments (5), Kingsoul (5), Voidheart (0)
            pd.charmCost_36 = pd.royalCharmState == 4 ? 0 : 5;
        if (pd.gotCharm_37)
            pd.charmCost_37 = 1;
        if (pd.gotCharm_38)
            pd.charmCost_38 = 3;
        if (pd.gotCharm_39)
            pd.charmCost_39 = 2;
        if (pd.gotCharm_40) // Grimmchild (2); Carefree Melofy (3)
            pd.charmCost_40 = pd.grimmChildLevel == 5 ? 3 : 2;
    }

    private int OnGetPlayerIntHook(string intName, int orig)
    {
        if (intName == "charmSlots")
        {
            var pd = PlayerData.instance;
            var notchCount = 3;
            notchCount += pd.salubraNotch1 ? 1 : 0;
            notchCount += pd.salubraNotch2 ? 1 : 0;
            notchCount += pd.salubraNotch3 ? 1 : 0;
            notchCount += pd.salubraNotch4 ? 1 : 0;
            notchCount += pd.notchFogCanyon ? 1 : 0;
            notchCount += pd.notchShroomOgres ? 1 : 0;
            notchCount += pd.colosseumBronzeCompleted ? 1 : 0;
            notchCount += pd.gotGrimmNotch ? 1 : 0;
        }

        return orig;
    }
}