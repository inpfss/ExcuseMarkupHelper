"""
What communication tactics are most frequently used in the US, UK or Canada
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
# get all country names mentioned in excuses
countries = excuseHelper.get_author_countries()

# list will contain pairs of country name and tactic index
tactics_list = []
# iterate through all excuses elements in XML
for excuse in excuseHelper.get_all_excuse_elements():
    # get name of country to which relates this excuse
    country_name = excuse.find('country').text
    # iterate through all tactics used in excuses
    for tactic in excuse.findall('communicativeTactics/communicativeTactic'):
        # add pair for current country statics
        tactics_list.append((country_name, tactic.attrib['tacticIndex']))
        # add pair for general statistics
        tactics_list.append(('general', tactic.attrib['tacticIndex']))

# build frequence usage of tactics in countries
tactics_usage_dic = ConditionalFreqDist(tactics_list)
# plot results with label
tactics_usage_dic.plot(title='Most frequently used tactics')

# print tactics
for tactic in excuseHelper.get_defined_tactics():
    print('{0}: {1}'.format(tactic[0], tactic[1]))