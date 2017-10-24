"""
How are combined communication tactics most often in the US, UK or Canada;
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
tactics_combination_list = []
# iterate through all communicativeTactics elements in XML
for excuse in excuseHelper.get_all_excuse_elements():
    # get country
    country = excuse.find('country').text
    # build list of used tactics indices in current excuse
    excuse_tactic_indices = ExcusesHelper.get_used_tactic_indices(excuse)
    # if in excuse are used more then one tactic
    # then we will save in list all possible combinations that we can deduce current combination
    # for example: (1, 4, 6) -> it covers following combinations
    # (1,4,6); (1,4); (1,6); (4,6)
    if len(excuse_tactic_indices) >= 2:
        # we want to get combination with length >= 2
        # we pass len(excuseTacticIndices) + 1, because range returns n elements starting from 0
        for combinationLength in range(2, len(excuse_tactic_indices) + 1):
            # now we use itertools to produce all combinations without repetitions
            combinations = list(itertools.combinations(excuse_tactic_indices, combinationLength))
            # add pair country and combination to the list
            tactics_combination_list += [(country, c) for c in combinations]

# build frequence usage of tactics
tactic_comb_dist = ConditionalFreqDist(tactics_combination_list)

# get all country names mentioned in excuses
countries = excuseHelper.get_author_countries()
for country in countries:
    # plot results
    tactic_comb_dist[country].plot(title='How are combined communication tactics most often in {0}'.format(country))
    print('Total count of tactics combination for {0}: {1}'.format(country, tactic_comb_dist[country].N()))
    print('Count of unique tactic combination for {0}: {1}'.format(country, tactic_comb_dist[country].B()))