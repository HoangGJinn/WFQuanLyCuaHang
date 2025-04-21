using System;

namespace DataAccessLayer
{
    public static class DALManager
    {
        private static DAL _instance;
        private static string _defaultConnectionString = @"Data Source=LAPTOP-L65KCPF3\SQLEXPRESS;Initial Catalog=LaptopStore2;Integrated Security=True";

        // Kiểm tra xem DAL đã được khởi tạo chưa
        public static bool IsInitialized => _instance != null;

        /// Khởi tạo DAL với chuỗi kết nối tùy chỉnh (thường sau đăng nhập)
        public static void Initialize(string connectionString)
        {
            if (_instance == null)
            {
                // Nếu chuỗi kết nối là null hoặc rỗng, sử dụng chuỗi kết nối mặc định
                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = _defaultConnectionString;
                }

                _instance = new DAL(connectionString);
            }
        }



        /// Lấy instance DAL hiện tại. Nếu chưa Initialize, sẽ trả về instance mặc định.
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

        /// Reset instance, ví dụ khi đăng xuất
        public static void Reset()
        {
            _instance = null;
        }
    }
}
    