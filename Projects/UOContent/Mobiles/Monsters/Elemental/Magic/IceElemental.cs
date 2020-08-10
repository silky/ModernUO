using Server.Items;

namespace Server.Mobiles
{
  public class IceElemental : BaseCreature
  {
    [Constructible]
    public IceElemental() : base(AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4)
    {
      Body = 161;
      BaseSoundID = 268;

      SetStr(156, 185);
      SetDex(96, 115);
      SetInt(171, 192);

      SetHits(94, 111);

      SetDamage(10, 21);

      SetDamageType(ResistanceType.Physical, 25);
      SetDamageType(ResistanceType.Cold, 75);

      SetResistance(ResistanceType.Physical, 35, 45);
      SetResistance(ResistanceType.Fire, 5, 10);
      SetResistance(ResistanceType.Cold, 50, 60);
      SetResistance(ResistanceType.Poison, 20, 30);
      SetResistance(ResistanceType.Energy, 20, 30);

      SetSkill(SkillName.EvalInt, 10.5, 60.0);
      SetSkill(SkillName.Magery, 10.5, 60.0);
      SetSkill(SkillName.MagicResist, 30.1, 80.0);
      SetSkill(SkillName.Tactics, 70.1, 100.0);
      SetSkill(SkillName.Wrestling, 60.1, 100.0);

      Fame = 4000;
      Karma = -4000;

      VirtualArmor = 40;

      PackItem(new BlackPearl());
      PackReg(3);
    }

    public IceElemental(Serial serial) : base(serial)
    {
    }

    public override string CorpseName => "an ice elemental corpse";
    public override string DefaultName => "an ice elemental";
    public override bool BleedImmune => true;

    public override void GenerateLoot()
    {
      AddLoot(LootPack.Average, 2);
      AddLoot(LootPack.Gems, 2);
    }

    public override void Serialize(IGenericWriter writer)
    {
      base.Serialize(writer);
      writer.Write(0);
    }

    public override void Deserialize(IGenericReader reader)
    {
      base.Deserialize(reader);
      int version = reader.ReadInt();
    }
  }
}