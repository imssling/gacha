// 選擇具有 ID 為 "sidebar-toggle" 的元素，這是側邊欄的切換按鈕
const sidebarToggle = document.querySelector("#sidebar-toggle");

// 為側邊欄切換按鈕添加點擊事件監聽器
sidebarToggle.addEventListener("click", function () {
    // 當切換按鈕被點擊時，切換側邊欄元素的 "collapsed" 類
    // 這將切換側邊欄的顯示和隱藏狀態
    document.querySelector("#sidebar").classList.toggle("collapsed");
});