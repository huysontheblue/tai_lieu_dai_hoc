# 4. Xoay ảnh sang trái với góc xoay lấy từ trackbar, tâm xoay nằm ở giữa ảnh
# https://aiots.vn/phan-6-xoay-va-dich-anh-su-dung-opencv/
import cv2
def funcRotate(degree=0):
    degree = cv2.getTrackbarPos('degree','Xoayanh')
    #lấy tâm xoay của ảnh
    center = (width/2, height/2)
    rotation_matrix = cv2.getRotationMatrix2D(center, degree, 1)
    rotated_image = cv2.warpAffine(img, rotation_matrix, (width, height))
    cv2.imshow('Sau khi xoay', rotated_image)

if __name__== '__main__':
    img=cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")
    height, width = img.shape[:2]
    cv2.namedWindow('Xoayanh')
    degree=0
    cv2.createTrackbar('degree','Xoayanh',degree,360,funcRotate)
    funcRotate(0)
    cv2.imshow('Xoayanh',img)
    cv2.waitKey(0)
cv2.destroyAllWindows()



