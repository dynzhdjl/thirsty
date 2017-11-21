namespace Thirsty.Repositories
{
    public static class QueryConstraintsExtenstions
    {
        public static string GetSortParameterString(this QueryConstraints constraints)
        {
            return constraints.SortOrder == SortOrder.Ascending ? "ASC" : "DESC";
        }
    }
}
