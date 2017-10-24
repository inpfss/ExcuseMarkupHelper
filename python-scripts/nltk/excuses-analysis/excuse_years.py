"""
How many excuses were among years
"""

# statistic class
from nltk import ConditionalFreqDist, FreqDist
# import our helper class to access excuses data from XML tree
from excuses_helper import ExcusesHelper

# need in order to read correctly excuses file in UTF-8 encoding
import sys

reload(sys)
sys.setdefaultencoding("utf-8")

def get_year(date_str):
    year = ''
    split_symbol = ''
    if date_str.find('.') > -1:
        split_symbol = '.'
    elif date_str.find('/') > -1:
        split_symbol = '/'
    if len(split_symbol) > 0:
        date_parts = date_str.split(split_symbol)
        year = date_parts[len(date_parts) - 1]
    else:
        year = date_str
    return int(year)


# create instance of helper
excuseHelper = ExcusesHelper()

# will contain statistic of excuses per year
excuses_year_dist = FreqDist()
# iterate through all excuses elements in XML
for excuse in excuseHelper.get_all_excuse_elements():
    # get gender of author
    date = excuse.find('date').text
    year = get_year(date)
    excuses_year_dist[year] += 1

# plot results with label
excuses_year_dist.plot(title=' ')
excuses_year_dist.tabulate()