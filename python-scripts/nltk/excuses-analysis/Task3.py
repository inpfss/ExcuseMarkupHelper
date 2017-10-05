'''
Які комунікативні тактики найчастіше вживають самі (без інших у вибаченні)
'''

import xml.etree.ElementTree as eT
from nltk.corpus.reader import XMLCorpusReader
from nltk.probability import FreqDist
import itertools
from matplotlib import pylab


reader = XMLCorpusReader('', 'ExcusesSample.xml')
root = eT.fromstring(reader.raw())

tacticsListSorted = sorted(set([tactic.find('name').text for tactic in root.findall('./excuse/tactics/tactic')]))

tacticsList = []
for excuseTactics in root.findall('./excuse/tactics'):
    excuseTacticNames = [tactic.find('name').text for tactic in excuseTactics.findall('tactic')]
    if len(excuseTacticNames) == 1:
        tacticIndex = tacticsListSorted.index(excuseTacticNames[0])
        tacticsList.append(tacticIndex)

for tacticName in tacticsListSorted:
    print('{0}: {1}'.format(tacticsListSorted.index(tacticName), tacticName))

dic = FreqDist(sorted(tacticsList))
dic.plot(title='Tactics used alone')
