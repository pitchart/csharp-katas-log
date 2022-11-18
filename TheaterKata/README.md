Original kata from [Emily Bache](https://github.com/emilybache/Theater-Kata) (in Java)

Kata Theater
============

You work for a theater, and you're working on a suggestion system
for seat allocations. During the process of buying tickets,
the customer is offered the best seats available in a given
price range. They will be shown a diagram of the theater with
all the available seats shown, and the suggested seats highlighted.
The customer will be able to change to different seats if they wish.

You do not need to write the code to display the theater layout
with the suggested seats highlighted. You just have to write the
code that decides which seats to suggest.

Business Rules
---------------

Offer seats following these rules, in this order:

- do not offer any seat that is already booked by another customer
- offer adjacent seats to members of the same party
- offer seats nearer the middle of a row
- offer seats nearer the stage

Sketch of the Theater
---------------------
This sketch might help you understand the provided test data better:

	    <------stage------->
         A1 A2 A3 A4 A5 A6 A7
        B1 B2 B3 B4 B5 B6 B7 B8
	  C1 C2 C3 C4 C5 C6 C7 C8 C9
      D1 D2 D3 D4 D5 D6 D7 D8 D9
	E1 E2 E3 E4 E5 E6 E7 E8 E9 E10
    F1 F2 F3 F4 F5 F6 F7 F8 F9 F10
	G1 G2 G3 G4 G5 G6 G7 G8 G9 G10