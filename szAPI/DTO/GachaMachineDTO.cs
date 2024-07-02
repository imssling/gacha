namespace szAPI.DTO
{
    public class GachaMachineDTO
    {
        public int id {  get; set; }
        public int themeId { get; set; }
        public string? machineName { get; set; }
        public string? machineDescription { get; set; }
        public string? machinePictureName { get; set; }
        public DateTime createTime { get; set; }
        public int price { get; set; }

    }
}