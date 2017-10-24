"""
Get alphabetic ordered list of all words that were used in excuses
"""

# need in order to read correctly excuses file in UTF-8 encoding
import sys

reload(sys)
sys.setdefaultencoding("utf-8")

# statistic class
# for splitting text into words
from nltk import word_tokenize, FreqDist
# import our helper class to access excuses data from XML tree
from excuses_helper import ExcusesHelper
# puctuation
import string

# punctuations symbols for splitting text to words
punctuations = string.punctuation
# create instance of helper
excuseHelper = ExcusesHelper()
# list of all words
words = []
# iterate through all excuses's tactics
for tactic in excuseHelper.get_tactics_elements():
    # get text of this tactic element
    tacticText = tactic.find('text').text
    # split text to words, skip punctuation, add them to list
    words += [word for word in word_tokenize(tacticText) if word not in punctuations]


dic = FreqDist(words)
dic.tabulate()

print(dic.N())
print(dic.B())
#
# # display unique words in alphabetic order
# for w in sorted(set(words)):
#     print(w)