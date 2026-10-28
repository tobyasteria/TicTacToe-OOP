
# AI USAGE LOG — WEEK 1

**Đề tài:** Tic-Tac-Toe OOP Game Engine  
**Công cụ AI:** ChatGPT

## 1. Nội dung AI hỗ trợ

- Phân tích yêu cầu đề tài và đề xuất kế hoạch thực hiện trong 4 tuần.
- Đề xuất thiết kế các class Board, Move, GameRules và Program.
- Hỗ trợ tạo source code C# ban đầu và đơn giản hóa cấu trúc project.
- Xây dựng 7 trường hợp kiểm thử cơ bản về nước đi hợp lệ, không hợp lệ, thắng và hòa.
- Hỗ trợ xây dựng sơ đồ UML, README và hướng dẫn sử dụng Git/GitHub.

## 2. Công việc sinh viên thực hiện

- Xác định sử dụng C# Console Application theo yêu cầu môn OOP.
- Xem xét thiết kế và yêu cầu điều chỉnh cấu trúc code để phù hợp với kiến thức đã học.
- Trực tiếp chạy chương trình bằng .NET SDK 8.0.416.
- Kiểm tra kết quả 7/7 test case PASS trên Terminal.
- Tổ chức source code, đưa project lên GitHub và xử lý các file build không cần thiết.

## 3. Kết quả và đánh giá

Hoàn thành bản triển khai nền tảng của trò chơi Tic-Tac-Toe với các class Board, Move và GameRules.

AI hỗ trợ tạo bản code ban đầu, trong khi sinh viên tham gia điều chỉnh hướng thiết kế, chạy kiểm thử và quản lý source code.

Các chức năng HumanPlayer, ComputerPlayer, Game Loop và Undo sẽ được triển khai trong những tuần tiếp theo.

# AI USAGE LOG — WEEK 2

**Đề tài:** Tic-Tac-Toe OOP Game Engine  
**Công cụ AI:** ChatGPT  
**Ngôn ngữ lập trình:** C# (.NET 8)

## 1. Nội dung AI hỗ trợ

- Hỗ trợ phân tích yêu cầu Tuần 2 và phân chia nhiệm vụ giữa hai thành viên.
- Đề xuất cách thiết kế interface `IPlayer` và class `Game` để quản lý lượt chơi.
- Hỗ trợ tạo code mẫu cho `Game.cs`, `IPlayer.cs` và tích hợp menu trong `Program.cs`.
- Hướng dẫn triển khai `HumanPlayer.cs` và `ComputerPlayer.cs`.
- Hỗ trợ phát hiện và sửa lỗi CS0535 do các class Player chưa triển khai đúng interface `IPlayer`.
- Giải thích cách áp dụng Polymorphism thông qua `GetMove()`.
- Hướng dẫn kiểm thử các chế độ chơi, điều kiện thắng/hòa và nước đi không hợp lệ.
- Hỗ trợ cập nhật UML, README và hướng dẫn thao tác Git/GitHub.

## 2. Công việc sinh viên thực hiện

**Lương Anh Hào (25110017):**
- Xem xét và điều chỉnh cấu trúc `IPlayer.cs`, `Game.cs`.
- Tích hợp các class vào `Program.cs` để tạo menu và chạy trò chơi.
- Tách các bài kiểm thử cũ sang `Week1Tests.cs`.
- Trực tiếp chạy kiểm thử Human vs Human, Human vs Computer, thắng/hòa và kiểm thử hồi quy.
- Cập nhật tài liệu và đưa source code, ảnh minh chứng lên GitHub.

**Nguyễn Quốc Hào (25110018):**
- Triển khai và điều chỉnh `HumanPlayer.cs`, `ComputerPlayer.cs` với sự hỗ trợ của AI.
- Sửa các phương thức và thuộc tính để tương thích với interface `IPlayer`.
- Bổ sung kiểm thử và commit phần công việc của mình trên GitHub.

## 3. Kết quả và đánh giá

- Hoàn thành hệ thống người chơi gồm `IPlayer`, `HumanPlayer` và `ComputerPlayer`.
- Chương trình đã có thể chơi Human vs Human và Human vs Computer.
- Đã kiểm thử các trường hợp thắng hàng ngang, hàng dọc, đường chéo, hòa và nhập nước đi không hợp lệ.
- Chạy lại 7 bài kiểm thử Tuần 1, tất cả đều PASS.
- Áp dụng Polymorphism thông qua interface `IPlayer` trong class `Game`.

AI được sử dụng để tham khảo cách thiết kế, tạo code mẫu và hỗ trợ sửa lỗi. Nhóm đã kiểm tra, điều chỉnh, tích hợp chương trình và chạy thử thực tế trước khi cập nhật repository.
