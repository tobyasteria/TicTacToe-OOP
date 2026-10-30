
# AI USAGE LOG — WEEK 4

**Đề tài:** Tic-Tac-Toe OOP Game Engine  
**Công cụ AI:** ChatGPT  
**Ngôn ngữ:** C# (.NET 8)  
**Chủ đề:** Final Testing, Integration and Documentation

## 1. Nội dung AI hỗ trợ

- Hỗ trợ lập kế hoạch hoàn thiện đồ án Tuần 4.
- Đề xuất bổ sung chức năng chạy toàn bộ test từ menu.
- Hướng dẫn tích hợp 3 bài kiểm thử Undo mới vào chương trình.
- Hướng dẫn kiểm thử hồi quy sau khi merge.

## 2. Công việc sinh viên thực hiện

**Lương Anh Hào (25110017):**

- Bổ sung `Run All Tests` vào `Program.cs`, giữ các lựa chọn kiểm thử riêng.
- Kiểm tra Pull Request #1 của Nguyễn Quốc Hào trước khi merge.
- Merge các bài kiểm thử mới vào nhánh `main`.
- Chạy `dotnet build` và kiểm thử tổng hợp.
- Xác nhận kết quả thực tế 18/18 PASS.
- Lưu ảnh minh chứng tại `docs/week4-regression-tests.png`.
- Cập nhật README và quản lý các commit trên GitHub.

**Nguyễn Quốc Hào (25110018):**

- Giữ nguyên 5 bài kiểm thử Undo cũ.
- Bổ sung `TestUndoRestoresTurn`, `TestUndoHumanVsComputer` và `TestInvalidMoveNotSaved`.
- Sử dụng Reflection và `ScriptedPlayer` để thiết lập, kiểm tra các tình huống.
- Chạy kiểm thử trên máy local, xác nhận 8/8 Undo Tests PASS.
- Lưu ảnh tại `docs/week4-undotest.png`.
- Commit trên branch `feature/week4-undo-tests` và tạo Pull Request #1.
- Kiểm tra UML; không chỉnh sửa vì kiến trúc chương trình không thay đổi.

## 3. Kết quả và đánh giá

Sau khi tích hợp Pull Request #1, nhóm đã chạy lại toàn bộ 18 bài kiểm thử:

- Week 1 Core Tests: 7/7 PASS.
- Week 2 Player Tests: 3/3 PASS.
- Undo Tests: 8/8 PASS.

**Tổng cộng: 18/18 PASS, 0 FAIL.**

Ba bài kiểm thử mới giúp kiểm tra việc khôi phục lượt chơi, hoàn tác hai nước trong Human vs Computer và bảo đảm nước đi không hợp lệ không được lưu vào lịch sử.

AI hỗ trợ hướng dẫn, đề xuất và review code. Nhóm trực tiếp thực hiện các thay đổi, chạy kiểm thử, xác nhận kết quả và quản lý Pull Request trên GitHub.

**Pull Request:** https://github.com/tobyasteria/TicTacToe-OOP/pull/1

**Minh chứng:** `docs/week4-regression-tests.png`
