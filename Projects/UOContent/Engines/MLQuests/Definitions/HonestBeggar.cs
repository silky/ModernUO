using System;
using Server.Engines.MLQuests.Objectives;
using Server.Engines.MLQuests.Rewards;
using Server.Engines.Spawners;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.MLQuests.Definitions
{
  public class HonestBeggar : MLQuest
  {
    public HonestBeggar()
    {
      Activated = true;
      Title = 1075392; // Honest Beggar
      Description =
        1075393; // Beg pardon, sir. I mean, madam. Uh, can I ask a favor of you? I found this jeweled ring.  Most people would sell it and keep the money, but not me. I ain't never stole nothing, and I ain't about to start. I tried to take it over to Brit castle, figgerin' it must belong to some highborn lady, but the guards threw me out. You look like they might let you pass. Will you take the ring over there and see if you can find the owner?
      RefusalMessage = 1075395; // I see. Too good to help an honest beggar like me, eh?
      InProgressMessage =
        1075396; // A jewel like this must be worth a lot, so it must belong to some noble or another. I would show it around the castle. Someone�s bound to recognize it.
      CompletionMessage =
        1075397; // Didst thou find my ring? I thank thee very much! It is an old ring, and a gift from my husband. I was most distraught when I realized it was missing.
      CompletionNotice = CompletionNoticeShort;

      Objectives.Add(new DeliverObjective(typeof(ReginasRing), 1, "Regina's Ring", typeof(Regina)));

      Rewards.Add(new DummyReward(1075394)); // Find the ring�s owner.
    }

    public override Type NextQuest => typeof(ReginasThanks);

    public override void Generate()
    {
      base.Generate();

      PutSpawner(new Spawner(1, 5, 10, 0, 4, "Evan"), new Point3D(1486, 1706, 0), Map.Trammel);
      PutSpawner(new Spawner(1, 5, 10, 0, 4, "Evan"), new Point3D(1486, 1706, 0), Map.Felucca);
    }
  }

  public class ReginasThanks : MLQuest
  {
    public ReginasThanks()
    {
      Activated = true;
      OneTimeOnly = true;
      Title = 1075398; // Regina�s Thanks
      Description =
        1075399; // What�s that you say? It was a humble beggar that found my ring? Such honesty must be rewarded. Here, take this packet and return it to him, and I will be in your debt.
      RefusalMessage = 1075401; // Hmph. Very well. What did you say his name was?
      InProgressMessage = 1075402; // Take the packet and return it to the beggar who found my ring.
      CompletionMessage =
        1075403; // What? For me? Let me see . . . these sapphire earrings are for you, it says. Oh, she wants to offer me a job! This is the most wonderful thing that ever happened to me!
      CompletionNotice = CompletionNoticeShort;

      Objectives.Add(new DeliverObjective(typeof(ReginasLetter), 1, "Regina's Letter", typeof(Evan)));

      Rewards.Add(new ItemReward(1075400, typeof(TransparentHeart))); // Transparent Heart
    }

    public override bool IsChainTriggered => true;

    public override void Generate()
    {
      base.Generate();

      PutSpawner(new Spawner(1, 5, 10, 0, 0, "Regina"), new Point3D(1362, 1622, 50), Map.Trammel);
      PutSpawner(new Spawner(1, 5, 10, 0, 3, "Regina"), new Point3D(1422, 1621, 20), Map.Felucca);
    }
  }

  public class Evan : BaseCreature
  {
    [Constructible]
    public Evan()
      : base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
    {
      Title = "the Beggar";
      Race = Race.Human;
      BodyValue = 0x190;
      Female = false;
      Hue = Race.RandomSkinHue();
      InitStats(100, 100, 25);

      Utility.AssignRandomHair(this);

      AddItem(new Backpack());
      AddItem(new Doublet());
      AddItem(new ShortPants(0x755));
    }

    public Evan(Serial serial)
      : base(serial)
    {
    }

    public override bool IsInvulnerable => true;
    public override string DefaultName => "Evan";

    public override void Serialize(IGenericWriter writer)
    {
      base.Serialize(writer);

      writer.Write(0); // version
    }

    public override void Deserialize(IGenericReader reader)
    {
      base.Deserialize(reader);

      int version = reader.ReadInt();
    }
  }

  public class Regina : BaseCreature
  {
    [Constructible]
    public Regina()
      : base(AIType.AI_Vendor, FightMode.None, 2, 1, 0.5, 2)
    {
      Title = "the Noble";
      Race = Race.Human;
      BodyValue = 0x191;
      Female = true;
      Hue = Race.RandomSkinHue();
      InitStats(100, 100, 25);

      Utility.AssignRandomHair(this);

      AddItem(new Backpack());
      AddItem(new GildedDress());
      AddItem(new Boots());
    }

    public Regina(Serial serial)
      : base(serial)
    {
    }

    public override bool IsInvulnerable => true;
    public override string DefaultName => "Regina";

    public override void Serialize(IGenericWriter writer)
    {
      base.Serialize(writer);

      writer.Write(0); // version
    }

    public override void Deserialize(IGenericReader reader)
    {
      base.Deserialize(reader);

      int version = reader.ReadInt();
    }
  }
}