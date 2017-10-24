"""
How communicative tactics are combined most frequently
"""

# statistic class
from nltk import ConditionalFreqDist
# import our helper class to access excuses data from XML tree
from excuses_helper import ExcusesHelper
# statistic class
from nltk import FreqDist

# need in order to read correctly excuses file in UTF-8 encoding
import sys
reload(sys)
sys.setdefaultencoding("utf-8")

# create instance of helper
excuseHelper = ExcusesHelper()
# for creating combinations of tactics
import itertools

# will contains all used combinations of tactics in all excuses
tacticsCombinationList = []
# iterate through all communicativeTactics elements in XML
for excuseTactics in excuseHelper.get_tactics_container_elements():
    # build list of used tactics indices in current excuse
    excuseTacticIndices = sorted([int(tactic.attrib['tacticIndex']) for tactic in excuseTactics])
    # if in excuse are used more then one tactic
    # then we will save in list all possible combinations that we can deduce current combination
    # for example: (1, 4, 6) -> it covers following combinations
    # (1,4,6); (1,4); (1,6); (4,6)
    if len(excuseTacticIndices) >= 2:
        # we want to get combination with length >= 2
        # we pass len(excuseTacticIndices) + 1, because range returns n elements starting from 0
        for combinationLength in range(2, len(excuseTacticIndices) + 1):
            # now we use itertools to produce all combinations without repetitions
            tacticsCombinationList += tuple((itertools.combinations(excuseTacticIndices, combinationLength)))

# build frequence usage of tactics
tactics_combination_freq_dist = FreqDist(tacticsCombinationList)
# plot results
tactics_combination_freq_dist.plot(title='Tactics combination statistic')
print('Total count of tactics combination: {0}'.format(tactics_combination_freq_dist.N()))
print('Count of unique tactic combination: {0}'.format(tactics_combination_freq_dist.B()))