using System.Collections.Generic;

namespace SaveData
{
    [System.Serializable]
    public class PinData
    {
        public List<int> Id = new();
        public List<string> Name = new();
        public List<string> Description = new();
        public List<float> PositionX = new();
        public List<float> PositionY = new();

        public List<PinInfo> GetAllInfoPins()
        {
            List<PinInfo> infoPins = new List<PinInfo>();

            for (int i = 0; i < Id.Count; i++)
            {
                PinInfo pinInfo = new PinInfo
                {
                    Id = Id[i],
                    Name = Name[i],
                    Description = Description[i],
                    PositionX = PositionX[i],
                    PositionY = PositionY[i]
                };

                infoPins.Add(pinInfo);
            }

            return infoPins;
        }

        public int GetIndexByPinInfo(PinInfo pinInfo)
        {
            for (int i = 0; i < Id.Count; i++)
            {
                if (Id[i] == pinInfo.Id)
                    return i;
            }
            return 0;
        }

        public bool HasPinInfoById(int id)
        {
            for (int i = 0; i < Id.Count; i++)
            {
                if (Id[i] == id)
                return true;
            }

            return false;
        }
    }
}