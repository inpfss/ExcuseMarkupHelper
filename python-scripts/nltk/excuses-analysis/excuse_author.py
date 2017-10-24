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

# create instance of helper
excuseHelper = ExcusesHelper()

# will contain statistic of excuses per author
excuses_author_dist = FreqDist()
# iterate through all excuses elements in XML
for excuse in excuseHelper.get_all_excuse_elements():
    # get gender of author
    author = excuse.find('author').text
    excuses_author_dist[author] += 1

# plot results with label
excuses_author_dist.plot(title=' ')
excuses_author_dist.tabulate()