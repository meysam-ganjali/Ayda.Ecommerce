using Ayda.Ecommerce.ShareModels.BaseModel;

namespace Ayda.Ecommerce.Utilities;

public static class DeleteFile
{

    public static ResultDto DeleteFileFromRoot(string path)
    {


        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
            return new ResultDto()
            {
                IsSuccess = true,
                Message = "فایل حذف گردید"
            };
        }
        else
        {
            return new ResultDto()
            {
                IsSuccess = false,
                Message = "فایل یافت نشد یا مسیر فایل اشتباه است"
            };
        }

    }
}