using System;

namespace KieuGiaConstruction.Models
{
    public class Project
    {
        public int Id { get; set; } // Khóa chính
        public required string ProjectName { get; set; } // Tên dự án
        public DateTime StartDate { get; set; } // Ngày bắt đầu
        public DateTime EndDate { get; set; } // Ngày kết thúc
        public required string iStatus { get; set; } // Trạng thái của dự án
    }
}
