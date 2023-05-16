
import pandas as pd

# Set display options
pd.set_option('display.max_columns', 10 )

# read data from csv file
dataset = pd.read_csv("D:\\XuLyAnh\\diabetes.csv", header=0)

# print first 5 rows of data set
print(dataset.head())
# describe dataset with statistic parameters

print(dataset.describe())
# count missing values for each columns containing missing data

print((dataset[['Glucose', 'BloodPressure', 'SkinThickness', 'Insulin', 'BMI']] == 0).sum())

