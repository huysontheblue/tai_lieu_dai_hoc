#1.	Viết chương trình tạo trackbar để thay đổi độ sáng và độ tương phản của ảnh
import cv2

def BrightnessContrast(brightness=0):
	
    # getTrackbarPos trả về hiện tại
    # vị trí của thanh theo dõi được chỉ định.
	brightness = cv2.getTrackbarPos('Brightness','Anh Goc')	
	contrast = cv2.getTrackbarPos('Contrast','Anh Goc')
	effect = controller(img, brightness,contrast)

	# Hàm imshow hiển thị hình ảnh
    # trong cửa sổ được chỉ định
	cv2.imshow('Anh Sau Khi Chinh', effect)

def controller(img, brightness=255,contrast=127):

	brightness = int((brightness - 0) * (255 - (-255)) / (510 - 0) + (-255))

	contrast = int((contrast - 0) * (127 - (-127)) / (254 - 0) + (-127))

	if brightness != 0:

		if brightness > 0:

			shadow = brightness

			max = 255

		else:

			shadow = 0
			max = 255 + brightness

		al_pha = (max - shadow) / 255
		be_ta = shadow

        # Hàm addWeighted tính toán
        # tổng trọng số của hai mảng
		cal = cv2.addWeighted(img, al_pha, img, 0, be_ta)

	else:
		cal = img

	if contrast != 0:
		alpha = float(131 * (contrast + 127)) / (127 * (131 - contrast))
		beta = 127 * (1 - alpha)

        # Hàm addWeighted tính toán
        # tổng trọng số của hai mảng
		cal = cv2.addWeighted(cal, alpha,cal, 0, beta)

    # putText hiển thị chuỗi văn bản được chỉ định trong hình ảnh.
	cv2.putText(cal, 'B:{},C:{}'.format(brightness,contrast), (10, 30),
	cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)

	return cal

if __name__ == '__main__':
    
    # Hàm imread tải một hình ảnh
    # từ tệp được chỉ định và trả về.
	original = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg")

	# Tạo một bản sao khác của hình ảnh.
	img = original.copy()

	# Hàm có tênWindow tạo ra một
    # cửa sổ có thể được sử dụng làm trình giữ chỗ
    # cho hình ảnh.
	cv2.namedWindow('Anh Goc')

	# Hàm imshow hiển thị một
    # hình ảnh trong cửa sổ được chỉ định.
	cv2.imshow('Anh Goc', original)

	# createTrackbar (trackbarName,
    # windowName, value, count, onChange)
    # Dải sáng -255 đến 255
	cv2.createTrackbar('Brightness','Anh Goc', 255, 2 * 255, BrightnessContrast)
	
	# Dải tương phản -127 đến 127
	cv2.createTrackbar('Contrast', 'Anh Goc', 127, 2 * 127, BrightnessContrast)

	BrightnessContrast(0)

cv2.waitKey(0)
cv2.destroyAllWindows()



# 2. Hiện ảnh trên matplotlib

import matplotlib.pyplot as plt
import matplotlib.image as mpimg
img = mpimg.imread("D:\\XuLyAnh\\sondeptrai.jpg")
imgplot = plt.imshow(img)
plt.show()


# 3. Viết chương trình biến đổi ảnh thành ảnh nhị phân, Tạo trackbar để thay đổi giá trị ngưỡng
import cv2

def trackChaned(x):
  pass
 
cv2.namedWindow('Trackbar nhi phan')
hh='Max'
hl='Min'
wnd = 'Colorbars'
cv2.createTrackbar("Max", "Trackbar nhi phan",0,255,trackChaned)
cv2.createTrackbar("Min", "Trackbar nhi phan",0,255,trackChaned)
img = cv2.imread("D:\\XuLyAnh\\sondeptrai.jpg",0)
img = cv2.resize(img, (0,0), fx=0.5, fy=0.5)
 
while(True):
   hul=cv2.getTrackbarPos("Max", "Trackbar nhi phan")
   huh=cv2.getTrackbarPos("Min", "Trackbar nhi phan")   
   ret,thresh4 = cv2.threshold(img,hul,huh,cv2.THRESH_TOZERO) 
   cv2.imshow("Anh son",thresh4)
   if cv2.waitKey(1) == ord('q'):
       break
cv2.destroyAllWindows()
