# gbboi-emu
A toy C# GameBoy (DMG-01) emulator

# Implemented opcodes
## Base
|    | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | A | B | C | D | E | F |
|:--:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|
| 0x | ✔ | ✔ | ✘ | 🟡 | 🟡 | 🟡 | 🟡 | 🟡 | ✘ | ✘ | ✘ | ✘ | 🟡 | 🟡 | 🟡 | ✘ |
| 1x | ✘ | 🟡 | ✘ | 🟡 | ✘ | 🟡 | 🟡 | ✘ | 🟡 | ✘ | 🟡 | ✘ | ✘ | 🟡 | 🟡 | ✘ |
| 2x | 🟡 | ✔ | 🟡 | 🟡 | 🟡 | ✘ | ✘ | ✘ | 🟡 | ✘ | ✘ | ✘ | ✘ | ✘ | 🟡 | ✘ |
| 3x | ✔ | ✔ | ✘ | ✘ | ✘ | ✔ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | 🟡 | 🟡 | ✘ |
| 4x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 5x | ✔ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | 🟡 | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 6x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✔ | 🟡 | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 7x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | 🟡 | 🟡 | ✘ | ✘ | 🟡 | 🟡 | ✘ | ✘ | ✘ |
| 8x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | 🟡 | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 9x | 🟡 | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| Ax | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✔ |
| Bx | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | 🟡 | ✘ |
| Cx | ✘ | ✘ | ✘ | ✔ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✔ | 🟡 | ✔ | ✘ |
| Dx | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | 🟡 | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| Ex | 🟡 | ✘ | 🟡 | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | 🟡 | ✘ | ✘ | ✘ | ✘ | ✘ |
| Fx | 🟡 | ✘ | ✘ | ✔ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✔ | ✘ | ✘ | 🟡 | ✔ |

## Two byte opcodes (CE-prefixed)
|    | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | A | B | C | D | E | F |
|:--:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|:-:|
| 0x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 1x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 2x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 3x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 4x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 5x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 6x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 7x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✔ | ✘ | ✘ | ✘ |
| 8x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| 9x | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| Ax | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| Bx | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| Cx | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| Dx | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| Ex | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |
| Fx | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ | ✘ |

## Key
| Symbol  | Meaning                      |
|---------|------------------------------|
| ✔       | Supported, with unit test    |
| 🟡       | Supported, unit tests needed |
| ✘       | Not supported at all         |
