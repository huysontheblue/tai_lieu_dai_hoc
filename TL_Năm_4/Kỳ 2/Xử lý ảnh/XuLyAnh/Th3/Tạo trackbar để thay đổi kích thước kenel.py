import cv2
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
def get_d(vitri):
    get_d.value = vitri
get_d.value = 1
cv2.namedWindow('Trackbar')
cv2.createTrackbar('x', 'Trackbar', 0, 11, get_d)
while(True):
    a = get_d.value
    img1 = cv2.bilateralFilter(img, a, 100, 100)
    cv2.imshow('Trackbar', img1)
    if cv2.waitKey(5)==ord('q'):
        break
cv2.imwrite('D:\\XuLyAnh\\anhloctrungbinh.jpg', img1)   
cv2.destroyAllWindows()