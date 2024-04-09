using DoAnLapTrinhWeb.Models;
using DoAnLapTrinhWeb.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ProjectName.Controllers
{
    public class BookController : Controller
    {

        private readonly ISachRepository _sachRepository;
        private readonly ITheLoaiRepository _theLoaiyRepository;
        private readonly ITacGiaRepository _tacGiaRepository;
        public BookController(ISachRepository sachRepository,

        ITheLoaiRepository theLoaiRepository,
        ITacGiaRepository tacGiaRepository)
            

        {
            _sachRepository = sachRepository;
            _theLoaiyRepository = theLoaiRepository;
            _tacGiaRepository = tacGiaRepository;
        }
        // Hiển thị danh sách sản phẩm
        public async Task<IActionResult> Index()


        {
            var products = await _sachRepository.GetAllAsync();
            return View(products);
        }
        // Hiển thị form thêm sản phẩm mới
        public async Task<IActionResult> Add()
        {
            var tbTheLoais = await _theLoaiyRepository.GetAllAsync();
            ViewBag.Book = new SelectList(tbTheLoais, "TheLoaiId", "tenTheLoai");
            var tbTacGias = await _tacGiaRepository.GetAllAsync();
            ViewBag.TacGia = new SelectList(tbTacGias, "TacGiaId", "TenTacGia");
            return View();

        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]

        public async Task<IActionResult> Add(tbSach sach, IFormFile imageUrl, IFormFile fileUrl)
        {
/*            if (ModelState.IsValid)*/
            {
/*                if (imageUrl== null)
                {
                    ModelState.AddModelError("imageUrl", "Vui lòng chọn file sách.");
                }*/
                if
                    (imageUrl != null && fileUrl != null)
                {
                    // Lưu hình ảnh đại diện
                    sach.imageUrl = await SaveImage(imageUrl);
                    sach.fileUrl = await SaveImage(fileUrl);

                }


                // Thêm sách vào cơ sở dữ liệu
                await _sachRepository.AddAsync(sach);

                // Chuyển hướng đến trang hiển thị danh sách sách sau khi thêm thành công
                return RedirectToAction(nameof(Index));

            }

            // Nếu ModelState không hợp lệ, hiển thị form với dữ liệu đã nhập
            var tbTheLoais = await _theLoaiyRepository.GetAllAsync();
            ViewBag.Book = new SelectList(tbTheLoais, "TheLoaiId", "tenTheLoai");
            var tbTacGia = await _tacGiaRepository.GetAllAsync();
            ViewBag.TacGia = new SelectList(tbTacGia, "TacGiaId", "TenTacGia");

            return View(sach);
        }



        // Viết thêm hàm SaveImage (tham khảo bài 02)
        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName); //

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return "/images/" + image.FileName; // Trả về đường dẫn tương đối
        }
        //Nhớ tạo folder images trong wwwroot

        // Hiển thị thông tin chi tiết sản phẩm
        public async Task<IActionResult> Display(int id)
        {
            var sach = await _sachRepository.GetByIdAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            return View(sach);
        }
        // Hiển thị form cập nhật sản phẩm
        public async Task<IActionResult> Update(int id)
        {
            var sach = await _sachRepository.GetByIdAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            var tbTheLoais = await _theLoaiyRepository.GetAllAsync();
            ViewBag.Book = new SelectList(tbTheLoais, "TheLoaiId", "tenTheLoai",
            sach.TheLoaiId);
            var tbTacGia = await _theLoaiyRepository.GetAllAsync();
            ViewBag.Book = new SelectList(tbTacGia, "TacGiaId", "tenTacGia",
            sach.TacGiaId);


            return View(sach);
        }
        // Xử lý cập nhật sản phẩm
        [HttpPost]
        public async Task<IActionResult> Update(int id, tbSach sach,

        IFormFile imageUrl)

        {
            ModelState.Remove("imageUrl"); // Loại bỏ xác thực ModelState cho


            if (id != sach.sachId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var existingProduct = await

                _sachRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync
                                                  // Giữ nguyên thông tin hình ảnh nếu không có hình mới được

                if (imageUrl == null)
                {
                    sach.imageUrl = existingProduct.imageUrl;
                }
                else
                {
                    // Lưu hình ảnh mới
                    sach.imageUrl = await SaveImage(imageUrl);
                }
                // Cập nhật các thông tin khác của sản phẩm

                existingProduct.tenSach = sach.tenSach;
                existingProduct.sachId = sach.sachId;
                existingProduct.fileUrl = sach.fileUrl;
                existingProduct.imageUrl = sach.imageUrl;
                await _sachRepository.UpdateAsync(existingProduct);
                return RedirectToAction(nameof(Index));
            }
            var tbTheLoais = await _theLoaiyRepository.GetAllAsync();
            ViewBag.Book = new SelectList(tbTheLoais, "maTheLoai", "tenTheLoai");
            return View(sach);
        }
        // Hiển thị form xác nhận xóa sản phẩm
        public async Task<IActionResult> Delete(int id)
        {
            var sach = await _sachRepository.GetByIdAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            return View(sach);
        }
        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sachRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}