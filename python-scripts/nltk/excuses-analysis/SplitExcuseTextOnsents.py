import xml.etree.ElementTree as eT
from nltk.corpus.reader import XMLCorpusReader
from nltk.tokenize import sent_tokenize
import codecs

import sys
reload(sys)
sys.setdefaultencoding("utf-8")


with open('applogies_1.xml', 'r') as xml_file:
    xml_tree = eT.parse(xml_file)

outXml = codecs.open('outXml.xml', 'w',encoding='utf8')
outXml.write('<?xml version="1.0" encoding="utf-8" ?>')
outXml.write('<excuses>')

for excuse in xml_tree.findall('./excuse'):
    outXml.write('<excuse>')

    excuseId = excuse.find('id').text
    outXml.write('<id>{0}</id>'.format(excuseId))

    text = excuse.find('text').text
    outXml.write('<text>{0}</text>'.format(text))

    sentences = sent_tokenize(text)
    outXml.write('<sentences>')
    for sentence in sentences:
        sentEnc = sentence
        outXml.write('<sentence><text>{0}</text></sentence>'.format(sentEnc))
    outXml.write('</sentences>')

    outXml.write('</excuse>')

outXml.write('</excuses>')
outXml.close()