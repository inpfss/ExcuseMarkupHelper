'''
Як найчастіше комбінують комунікативні тактики в одному вибаченні
'''

import xml.etree.ElementTree as eT
from nltk.corpus.reader import XMLCorpusReader
from nltk.probability import FreqDist
import itertools
from matplotlib import pylab


reader = XMLCorpusReader('', 'ExcusesSample.xml')
root = eT.fromstring(reader.raw())

tacticsListSorted = sorted(set([tactic.find('name').text for tactic in root.findall('./excuse/tactics/tactic')]))

tacticsCombinationList = []
for excuseTactics in root.findall('./excuse/tactics'):
    excuseTacticNames = sorted([tactic.find('name').text for tactic in excuseTactics.findall('tactic')])
    tacticIndexies = sorted([tacticsListSorted.index(name) for name in excuseTacticNames])
    if len(excuseTacticNames) >= 2:
        for combinationLength in range(2, len(tacticIndexies) + 1):
            tacticsCombinationList += tuple(itertools.combinations(tacticIndexies, combinationLength))

for tacticName in tacticsListSorted:
    print('{0}: {1}'.format(tacticsListSorted.index(tacticName), tacticName))

dic = FreqDist(sorted(tacticsCombinationList))
dic.plot(title='Tactics combination statistic')
