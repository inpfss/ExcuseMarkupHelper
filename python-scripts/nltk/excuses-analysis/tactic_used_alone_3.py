"""
What communication tactics use themselves (without others to apologize)
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
# will contain tactic indices
tacticsList = []
# iterate through all communicativeTactics elements in XML
for excuseTactics in excuseHelper.get_tactics_container_elements():
    # build list of used tactics indices in current excuse
    excuseTacticIndices = [int(tactic.attrib['tacticIndex']) for tactic in excuseTactics]
    # if only one tactic is used in the excuse, then add it to list
    if len(excuseTacticIndices) == 1:
        tacticsList.append(excuseTacticIndices[0])

# build frequence usage of tactics
tactics_freq_dist = FreqDist(tacticsList)
# plot results
tactics_freq_dist.plot(title='Tactics used alone')