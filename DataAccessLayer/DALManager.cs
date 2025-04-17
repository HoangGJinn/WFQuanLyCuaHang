using System;

namespace DataAccessLayer
{
    public static class DALManager
    {
        private static DAL _instance;
        private static string _defaultConnectionString = @"Data Source=.;Initial Catalog=LaptopStore2;Integrated Security=True";

        // Kiểm tra xem DAL đã được khởi tạo chưa
        public static bool IsInitialized => _instance != null;

        /// <summary>
        /// Khởi tạo DAL với chuỗi kết nối tùy chỉnh (thường sau đăng nhập)
        /// </summary>
        public static void Initialize(string connectionString)
        {
            if (_instance == null)
            {
                _instance = new DAL(connectionString);
            }
        }

        /// <summary>
        /// Lấy instance DAL hiện tại. Nếu chưa Initialize, sẽ trả về instance mặc định.
        /// </summary>
        public static DAL Instance
        {
            get
            {
                if (_instance == null)
                {
                    // Cho phép dùng DAL mặc định khi chưa đăng nhập
                    _instance = new DAL(_defaultConnectionString);
                }
                return _instance;
            }
        }

        /// <summary>
        /// Reset instance, ví dụ khi đăng xuất
        /// </summary>
        public static void Reset()
        {
            _instance = null;
        }
    }
}
    