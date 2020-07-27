﻿using TaleWorlds.CampaignSystem.ViewModelCollection;

namespace PartyScreenEnhancements.Comparers
{
    public class TypeComparer : PartySort
    {
        public TypeComparer(PartySort equalSorter, bool descending) : base(equalSorter, @descending, null)
        {
        }

        internal TypeComparer()
        {

        }

        public override string GetHintText()
        {
            return
                "Compares units based on their Formation Class.\nAscending order is low to high.\nDescending order is high to low.";
        }

        public override string GetName()
        {
            return "Formation Type Comparer";
        }

        public override bool HasCustomSettings()
        {
            return false;
        }

        protected override int localCompare(ref PartyCharacterVM x, ref PartyCharacterVM y)
        {
            if (Descending
                ? x.Character.DefaultFormationClass < y.Character.DefaultFormationClass
                : x.Character.DefaultFormationClass > y.Character.DefaultFormationClass) return 1;

            if (y.Character.DefaultFormationClass == x.Character.DefaultFormationClass)
            {
                if (EqualSorter != null)
                    return EqualSorter.Compare(x, y);
                return 0;
            }

            return -1;
        }
    }
}