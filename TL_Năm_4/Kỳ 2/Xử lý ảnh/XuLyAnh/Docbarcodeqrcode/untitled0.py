# import EAN13 from barcode module
from barcode import EAN13

# import ImageWriter to generate an image file
from barcode.writer import ImageWriter

# Make sure to pass the number as string
number = '5901234123457'

# Now, let's create an object of EAN13 class and
# pass the number with the ImageWriter() as the
# writer
my_code = EAN13(number, writer=ImageWriter())

# Our barcode is ready. Let's save it.
my_code.save("new_code1")

import cv2
img = cv2.imread("D:\\XuLyAnh\Đọc barcode, qrcode\new_code1.png")
cv2.imshow('moi luu', img)
cv2.waitKey()
cv2.destroyAllWindows()
