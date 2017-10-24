"""
What communication tactics are most frequently used by men and women
"""

# statistic class
from nltk import ConditionalFreqDist
# import our helper class to access excuses data from XML tree
from excuses_helper import ExcusesHelper

# need in order to read correctly excuses file in UTF-8 encoding
import sys

reload(sys)
sys.setdefaultencoding("utf-8")

# create instance of helper
excuseHelper = ExcusesHelper()

# list will contain pairs of gender and tactic index
tactics_list = []
# iterate through all excuses elements in XML
for excuse in excuseHelper.get_all_excuse_elements():
    # get gender of author
    gender = excuse.find('gender').text
    # skip group excuses
    if gender != 'male' and gender != 'female':
        continue

    # add tactics indices with gender to the list
    for tacticIndex in ExcusesHelper.get_used_tactic_indices(excuse):
        tactics_list.append((gender, tacticIndex))

# build frequence usage of tactics in countries
tactics_usage_dic = ConditionalFreqDist(tactics_list)
# plot results with label
tactics_usage_dic.plot(title='What communication tactics are most frequently used by men and women')
tactics_usage_dic.tabulate()