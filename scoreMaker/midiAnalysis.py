from music21 import converter, instrument, note, chord, stream

nocturne = converter.parse("test.mid")

parts = instrument.partitionByInstrument(nocturne)

notes_to_parse = parts.parts[1].recurse()  # 対象のパートを一つに絞る

string_nocturne_notes = []

for element in notes_to_parse:
    if isinstance(element, note.Note):
      string_nocturne_notes.append(str(element.pitch))
    elif isinstance(element, chord.Chord):
      string_nocturne_notes.append('.'.join(str(n) for n in element.normalOrder))

print(notes_to_parse)

s = converter.parse('tinyNotation: 4/4 e8 e8 r e8 r c8 e8 r g4 r G4 r')
s.show()
