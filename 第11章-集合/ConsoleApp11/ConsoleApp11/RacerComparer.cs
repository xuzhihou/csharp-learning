public class RacerComparer : IComparer<Racer>
{
	private CompareType _compareType;
	public RacerComparer(CompareType compareType)
	{
		_compareType = compareType;
	}
	public enum CompareType
	{
		Wins,
		LastName,
		FirstName,
		Country
	}
	public int Compare(Racer x, Racer y)
	{
		if(x==null &&y==null) return 0;
		if (x == null) return -1; if (y == null) return 1;
		int result;
		switch(_compareType)
		{
			case CompareType.Wins:
				result = x.Wins > y.Wins ? 1 : -1;
				break;
			case CompareType.LastName:
				result = x.LastName?.CompareTo(y.LastName) ?? -1;
				break;
			case CompareType.FirstName:
				result = x.FirstName?.CompareTo(y.FirstName) ?? -1;
				break;
			case CompareType.Country:
				result = x.Country?.CompareTo(y.Country) ?? -1;
				break;
			default:
				result = 0;
				throw new InvalidOperationException("Invalid CompareType");
				break;
		}
		return result;
	}
}