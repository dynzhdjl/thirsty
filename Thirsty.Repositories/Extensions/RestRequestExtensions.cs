using RestSharp;

namespace Thirsty.Repositories
{
    public static class RestRequestExtensions
    {
        public static void ApplyConstraints(this RestRequest request, IQueryConstraints constraints)
        {
            if(constraints == null)
            {
                return;
            }
            request.AddParameter("p", constraints.PageNumber);
            request.AddParameter("order", constraints.SortPropertyName);
            request.AddParameter("sort", constraints.SortOrder == SortOrder.Ascending ? "ASC" : "DESC");
            foreach (var item in constraints.FilterParameters)
            {
                request.AddParameter(item.Key, item.Value);
            }
        }
    }
}
