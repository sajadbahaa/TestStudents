namespace Dtos.ItemWithSpeclizeDtos
{
    public class addUpdateSpecilizesDto
    {
        public short specilizeId { get; set; }
        public string specilizeName { get; set; }

        public addUpdateSpecilizesDto()
        {
            specilizeId = 0;
            specilizeName = string.Empty;
        }
    }
}
