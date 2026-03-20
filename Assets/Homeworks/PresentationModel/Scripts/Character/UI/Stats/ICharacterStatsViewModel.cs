using System.Collections.Generic;

public interface ICharacterStatsViewModel : IViewModel
{
    List<CharacterStat> Stats { get; }

   void ChangeStats(List<CharacterStat> stats);
}
