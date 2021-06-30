using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeDetailS.Core.Model
{
    public class FilesModel
    {
        public int FileID { get; set; }
        [Required]
        public IFormFile FilE  { get; set; }

        public byte[] UploadFile { get; set; }

        public string filesname { get; set; }

    }
}
