namespace IndWalks.API.Model.DTO
{
    public class UpdateRegionFromUser
    {
        public string Code { get; set; } // Represents Code of Region ex Nearl will be NRL

        public string Name { get; set; } // This Represnt Name of region 

        public string? RegionImageUrl { get; set; } // Image Of Region
    }
}
