# Biến đổi ảnh sang ảnh nhị phân với ngưỡng thay đổi từ trackbar. 
# Biến đổi ảnh nhị phân thành ảnh âm bản, lưu lại ảnh âm bản
import cv2
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg",0)
def get_nguong(vitri):
        get_nguong.value = vitri
get_nguong.value = 127
cv2.namedWindow('Nhiphan')
cv2.createTrackbar('dentrang:', 'Nhiphan', 127, 200, get_nguong)
while(True):
    #lấy ngưỡng:
    nguong = get_nguong.value
    #hàm phân ngưỡng:
    ret,anh =cv2.threshold(img, nguong, 255, cv2.THRESH_BINARY)
    neg =255 - img
    cv2.imshow('Nhiphan',anh)
    cv2.imshow('Anh am ban', neg)
    #gọi hàm thay đổi độ sáng 
    if cv2.waitKey(5)==ord('q'):
        break
cv2.imwrite('D:\\XuLyAnh\\amban.jpg', neg)
cv2.waitKey(0)
cv2.destroyAllWindows()