namespace TrackUs.Data.Models.Services
{
    using TrackUs.Data.Common.Models;

    public class Error : BaseModel<int>
    {
        public string ErrorName { get; set; }

        public Response Response { get; set; }

        public int ResponseId { get; set; }
    }
}